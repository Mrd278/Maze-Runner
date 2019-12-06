using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    public GameObject Flash;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("torch"))
        {
            if(Flash.activeSelf)
            {
                Flash.SetActive(false);
            }
            else if (!Flash.activeSelf)
            {
                Flash.SetActive(true);
            }
        }
    }
}
