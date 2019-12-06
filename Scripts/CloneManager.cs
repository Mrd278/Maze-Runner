using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{
    public string[] clone;
    public GameObject[] clones;
    public float time = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            time = (time + 1) % 5;
        }

        if (time == 4)
        {
            for (int i = 0; i < clone.Length; i++)
            {
                clones = GameObject.FindGameObjectsWithTag(clone[i]);
                for (int j = 0; j < clones.Length; j++)
                {
                    Destroy(clones[j].gameObject);
                }
            }
        }
    }
}
