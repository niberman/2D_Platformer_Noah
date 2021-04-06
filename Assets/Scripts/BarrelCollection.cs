using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollection : MonoBehaviour
{
    public int speed;
    private bool pickedUp = false;

    public AudioSource sound;

    void Start()
    {
    }

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

            sound.Play();
            Destroy(gameObject, 0.1f);
        }
    }

}
