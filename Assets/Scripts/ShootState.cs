using UnityEngine;

public class ShootState : PlayerBaseState
{
    private float Cooldown = 1;
    private int Bullet;
    public GameObject BulletPrefab;
    private int fireRate = 1; // Fire rate in seconds
    
    // Store reference to the state machine
    // No factory needed based on PlayerStateMachine.cs structure
private PlayerStateMachine stateMachine;
    public ShootState(PlayerStateMachine stateMachine) : base(stateMachine) 
    { 
        this.stateMachine = stateMachine;
    }

    void Start()
    {
        
            
    }
    void Update()
    {
        
   
            Cooldown = fireRate; // Reset cooldown
        
         
    }
    public override void Enter()
    {
        // Logic when entering the shoot state (e.g., play animation, aim)
        Debug.Log("Player entered Shoot State");
         stateMachine.Animator.SetBool("IsShooting", true); // Example animation trigger
         
         if (Input.GetButtonDown("Fire1") && Cooldown <= 0)
        {
            // Fire the bullet
            Debug.Log("Bullet Fired");
            GameObject bullet = GameObject.Instantiate(BulletPrefab, stateMachine.transform.position, Quaternion.identity);
            Bullet script = bullet.GetComponent<Bullet>();
            Cooldown = fireRate; // Reset cooldown
        }
    }

    public override void Tick(float deltaTime)
    {
        // Logic during the shoot state (e.g., handle firing cooldown, check ammo)

        // Check for transitions out of the shoot state
        // Check for transitions out of the shoot state
        CheckSwitchStates(); // We'll keep this helper method for clarity
    }

    public override void Exit()
    {
        // Logic when exiting the shoot state (e.g., stop animation)
        Debug.Log("Player exited Shoot State");
         stateMachine.Animator.SetBool("IsShooting", false); // Example animation reset
    }

    // Helper method for transition checks (called from Tick)
    private void CheckSwitchStates()
    {
        // If shoot button is released, transition to appropriate state
        if (!stateMachine.InputReader.IsShootPressed())
        {
            // Allow jump out of shoot if jump pressed
            if (stateMachine.InputReader.IsJumpPressed() && stateMachine.JumpsRemaining > 0)
            {
                stateMachine.SwitchState(stateMachine.JumpState);
                return;
            }

            if (stateMachine.IsGrounded())
            {
                if (stateMachine.InputReader.IsCrouchHeld())
                {
                    stateMachine.SwitchState(stateMachine.CrouchState);
                }
                else
                {
                    Vector2 moveInput = stateMachine.InputReader.GetMovementInput();
                    if (moveInput == Vector2.zero)
                        stateMachine.SwitchState(stateMachine.IdleState);
                    else if (stateMachine.InputReader.IsRunPressed())
                        stateMachine.SwitchState(stateMachine.RunState);
                    else
                        stateMachine.SwitchState(stateMachine.WalkState);
                }
            }
            else
            {
                // Airborne: check for wall cling or fall
                if (stateMachine.IsTouchingWall() && stateMachine.RB.linearVelocity.y <= 0)
                {
                    stateMachine.SwitchState(stateMachine.WallClingState);
                }
                else
                {
                    stateMachine.SwitchState(stateMachine.FallState);
                }
            }
        }
    }

    // No InitializeSubState in the base class shown in PlayerStateMachine.cs
}