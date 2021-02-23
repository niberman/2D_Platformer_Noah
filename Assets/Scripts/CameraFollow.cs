using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float xMax, xMin, yMax, yMin;
    
    GameObject cameraTarget;
    Transform target;

    void LateUpdate()
    {
        cameraTarget = GameObject.Find("Player");
        target = cameraTarget.transform;
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax),
            Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);

        //Debug.Log(target.transform.position);
    }
}
