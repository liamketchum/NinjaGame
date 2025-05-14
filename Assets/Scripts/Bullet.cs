using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int direction;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * direction * 4f * Time.deltaTime);
    }
}
