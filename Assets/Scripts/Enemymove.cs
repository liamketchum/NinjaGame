using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine.Timeline;
public class Enemymove : MonoBehaviour
{
    private bool isMovingleft = true;
    private GameObject player;
    [SerializeField]private states state;
    private bool startofstate = true;
    private enum states 
    {
        patrol
    }

    private int _speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        _speed = 5;
      
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with  + {other.gameObject.name}");
        if (other.gameObject.CompareTag("Trigger"))
        {
            isMovingleft = !isMovingleft;
            print("triggered");
        }
    }
    void patrol()
    {
        if (isMovingleft)
        {
            transform.position = new Vector3(transform.position.x - _speed * Time.deltaTime, transform.position.y, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(transform.position.x + _speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        patrol();

    }
}
