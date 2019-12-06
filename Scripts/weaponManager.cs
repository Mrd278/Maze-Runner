using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    public GameObject[] weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Weapon 1"))
        {
            for(int i = 0; i < weapon.Length; i++)
            {
                if(weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[0].gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Weapon 2"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[1].gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Weapon 3"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[2].gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Weapon 4"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[3].gameObject.SetActive(true);
        }
        /*if (Input.GetButtonUp("Weapon 5"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[4].gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Weapon 6"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[5].gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Weapon 7"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[6].gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Weapon 8"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[7].gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Weapon 9"))
        {
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].gameObject.activeSelf)
                {
                    weapon[i].gameObject.SetActive(false);
                }
            }
            weapon[8].gameObject.SetActive(true);
        }*/
    }
}
