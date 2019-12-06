using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootpebble : MonoBehaviour
{
    public Camera cam;
    public GameObject pebble;
    public Transform Hand;
    public float shootforce;
    public ActionPoint action;

    public void Update()
    {
        if (action.pebbledetected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject go = Instantiate(pebble, Hand.position, Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.velocity = cam.transform.forward * shootforce;
                action.pebbledetected = false;
            }
        }
    }
}
