using UnityEngine;

public class ShootState : PlayerBaseState
{
    //private int Bullet;
    public GameObject BulletPrefab; // Assign this in the Unity Editor or ensure it's not null at runtime
    
    // Store reference to the state machine
    // No factory needed based on PlayerStateMachine.cs structure
private PlayerStateMachine stateMachine;
    public ShootState(PlayerStateMachine stateMachine) : base(stateMachine) 
    { 
        this.stateMachine = stateMachine;
    }

    
   
    public override void Enter()
    {
        // Logic when entering the shoot state (e.g., play animation, aim)
        Debug.Log("Player entered Shoot State");
        stateMachine.Animator.SetBool("IsShooting", true); // Example animation trigger
         
        
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.Cooldown < 0) {
            Shoot();
            stateMachine.Cooldown = 1f;
        }

        stateMachine.SwitchState(stateMachine.IdleState);
    }

    public override void Exit()
    {
        // Logic when exiting the shoot state (e.g., stop animation)
        Debug.Log("Player exited Shoot State");
        stateMachine.Animator.SetBool("IsShooting", false); // Example animation reset
    }

    private void Shoot() {
        // Instantiate bullet
        Bullet bullet = GameObject.Instantiate(stateMachine.bulletPrefab, stateMachine.transform.position, Quaternion.identity).GetComponent<Bullet>();
        // set bullet direction/speed
        bullet.direction = (int)stateMachine.GetMovementInput().x;
    }
}