using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoint : MonoBehaviour
{
    public float weaponRange = 50f;
    public Transform Actionpoint;
    public bool pebbledetected = false;

    public void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Actionpoint.position, Actionpoint.forward, out hit, weaponRange))
            {
                if (hit.collider.tag == "pebble")
                {
                    GameObject pebble = (GameObject)hit.transform.gameObject;
                    pebbledetected = true;
                    Destroy(pebble);
                }
            }
            else
            {
                return;
            }
        }
    }
}
