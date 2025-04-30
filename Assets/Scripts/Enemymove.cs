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
    public List<gameObject> waypoints;
    private it currentPoint;
    private Vector3 targetPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
