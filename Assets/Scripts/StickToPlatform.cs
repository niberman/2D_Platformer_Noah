using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{

    Rigidbody body;
    Transform collidedObject;

    void OnCollisionEnter(Collision collision)
    {
        colliedObject = collison.transform;
        if (!body)
        {
            if (collision.gameobject.GetComponent<Rigidbody>())
            {
                body = collision.gameobject.GetComponent<Rigidbody>();
            }
        }
        if (body)
            body.isKinematic = true;
        this.gameobject.transform.setparent(collision.gameobject.transform);
    }

    void Update()
    {

        if (collidedObject)
        {
            collidedObject.parent = null;
            if (body)
            {
                body.isKinematic = false;
                body = null;
            }
        }

    }
}
