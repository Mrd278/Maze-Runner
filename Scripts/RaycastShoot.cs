using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public float weaponRange = 50f;
    public Transform gunEnd;
    public PlayerStats Player;

    
    public void Raycastfire()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunEnd.transform.position, gunEnd.transform.forward, out hit, weaponRange))
        {
            if(hit.collider.tag == "Player")
            {
                //Reduce Health;
                Player.Reducehealth();
            }
        }
        else
        {
            return;
        }
    }
}
