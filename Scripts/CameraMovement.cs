using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speedv = 2.0f;
    public float speedh = 2.0f;

    public GameObject player;
    private float yaw = 0f;
    private float pitch = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedh * Input.GetAxis("Mouse X");
        pitch -= speedv * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        player.transform.eulerAngles = new Vector3(0f, yaw, 0f);
    }
}
