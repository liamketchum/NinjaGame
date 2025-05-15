using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine.Timeline;
public class Enemymove : MonoBehaviour
{
    [SerializeField] private int enemyhealth =1;
    private bool isMovingleft = true;
    private GameObject player;
    [SerializeField]private states state;
    private bool startofstate = true;
    
public GameObject enemy;
    public  List<GameObject> waypoints;
    public Vector2 target;
    public int waypointsIndex = 0;

    public LevelLoader levelLoader;

    
    private enum states 
    {
        patrol
    }

    private int _speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       levelLoader = FindObjectOfType<LevelLoader>();
        _speed = 3;

        if (levelLoader.isLoaded)
        {
            waypoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Waypoint"));
            target = waypoints[waypointsIndex].transform.position;
        }
    }

    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Debug.Log("Hit");
           Destroy(other.gameObject);
            if (enemyhealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                enemyhealth--;
            }
        }
    }
    
    void patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            waypointsIndex++;
            if (waypointsIndex >= waypoints.Count)
            {
                waypointsIndex = 0;
            }
            target = waypoints[waypointsIndex].transform.position;
        }   
        /*
        if (isMovingleft)
        {
            transform.position = new Vector3(transform.position.x - _speed * Time.deltaTime, transform.position.y, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(transform.position.x + _speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        */
    }
    // Update is called once per frame
    void Update()
    {
        patrol();

    }
}
