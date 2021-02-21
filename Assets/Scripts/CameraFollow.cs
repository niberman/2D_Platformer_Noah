using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    private GameObject cameraTarget;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraTarget = GameObject.Find("Player");
        target = cameraTarget.transform;
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax),
            Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);

        Debug.Log(target.transform.position);
    }
}
