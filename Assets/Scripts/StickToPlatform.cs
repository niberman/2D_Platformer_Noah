using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = new Vector2(platform.transform.position.x, platform.transform.position.y);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.transform.position = player.transform.position;
    }
}
