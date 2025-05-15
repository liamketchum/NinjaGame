using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int direction;
    // Update is called once per frame
    
    void Start()
    {
        Destroy(gameObject, 2f); // Destroy the bullet after 2 seconds
    }
    
        void Update()
    {
        transform.Translate(Vector3.right * direction * 4f * Time.deltaTime);
    }
}
