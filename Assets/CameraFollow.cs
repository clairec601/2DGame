using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Vector3 position;

    void Start()
    {
        position = transform.position; //access to "Position" component of Transform of camera
    }

    // Update is called once per frame
    void Update()
    {
        position.x = player.transform.position.x;
        position.y = player.transform.position.y; //adjusts y position  
        transform.position = position; //stores position to position referenced by Transform
    }
}
