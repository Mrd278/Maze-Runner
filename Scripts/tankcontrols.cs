using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankcontrols : MonoBehaviour
{
    public GameObject theplayer;
    public bool ismoving;
    public float horizontal;
    public float vertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            ismoving = true;
            theplayer.GetComponent<Animator>().Play("Walk");
            horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 100;
            vertical = Input.GetAxis("Vertical") * Time.deltaTime * 4;
            theplayer.transform.Rotate(0, horizontal, 0);
            theplayer.transform.Translate(0, 0, vertical);
        }
        else if (Input.GetButton("Jump"))
        {
            theplayer.GetComponent<Animator>().Play("Jump");
        }
        else
        {
            ismoving = false;
            theplayer.GetComponent<Animator>().Play("Idle");
        }

    }
}
