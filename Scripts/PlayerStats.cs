using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 100f;
    
    public void Reducehealth()
    {
        health -= 1f;
    }
}
