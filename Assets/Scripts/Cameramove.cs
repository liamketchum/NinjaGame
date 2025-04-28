using UnityEngine;

public class Cameramove : MonoBehaviour
{
    public Transform player;
    public Vector2 offset;
    public float smoothSpeed = 0.04f;
    private Vector3 velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Vector3 desiredPosition = new Vector3(player.position.x,   player.position.y,   transform.position.z) + new Vector3(offset.x, offset.y, 0);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
