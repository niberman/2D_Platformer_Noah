using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollection : MonoBehaviour
{
    public int speed;
    private bool pickedUp = false;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!pickedUp)
                pickedUp = true;

            Destroy(gameObject, 0.1f);
        }
    }

}
