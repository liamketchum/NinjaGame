using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine.Timeline;
public class Enemymove : MonoBehaviour
{
    [SerializeField]private states state;
    private bool startofstate = true;
    private enum states 
    {
        patrol
    }
    private GameObject player;
    public List<GameObject> waypoints;
    private int currentPoint;
    private Vector3 targetPos;
    private int _speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPoint = 0;
        _speed = 1;
        patrol();
    }

    void OnTrigerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetPos = (other.gameObject.transform.position);
        }

    }

    void patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentPoint].transform.position, _speed * Time.deltaTime);   
        if (Vector3.Distance(transform.position, waypoints[currentPoint].transform.position) < 0.1f)
        {
            currentPoint++;
            if (currentPoint >= waypoints.Count)
            {
                currentPoint = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
