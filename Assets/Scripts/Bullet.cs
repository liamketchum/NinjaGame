using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed=4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
