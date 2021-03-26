using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    /* Task
     * convert vector3 points array to gameobject array
     * be able to drag and drop gameobject into platform to get transform*/

    //public Vector3[] points;
    public GameObject[] points;
    public int pointNumber = 0;
    private Vector3 currentTarget;

    public float tolerance;
    public float speed; //speed of platform
    public float delayTimer; //how long the platform moves

    private float delayStart;

    public bool automatic; //move platform on its own

    private void Start()
    {
        if(points.Length > 0)
        {
            //currentTarget = points.Length == 0; //error
            currentTarget = 
        }
        tolerance = speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(transform.position != currentTarget)
            MovePlatform();
        else
            UpdateTarget();
    }

    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;

        if(heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }
    }

    void UpdateTarget()
    {
        if (automatic)
            if (Time.time - delayStart > delayTimer)
                NextPlatform();
    }

    public void NextPlatform()
    {
        pointNumber++;
        if (pointNumber >= points.Length)
            pointNumber = 0;

        // currentTarget = points[pointNumber]; //error
        currentTarget = 
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
