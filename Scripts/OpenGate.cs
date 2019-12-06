using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject Gate;
    private Animator anim;
    public bool Gateisopen = false;
    

    private void Start()
    {
        anim = Gate.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "pebble")
        {
            Debug.Log("Pebble");
            //anim.SetBool("open", true);
            anim.SetBool("open", true);
            Gateisopen = true;
        }
    }
}
