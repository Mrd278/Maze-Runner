using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Skeleton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Create_Enemy(other.transform.position));
        }
    }

    IEnumerator Create_Enemy(Vector3 pos)
    {
        yield return new WaitForSeconds(2f);
        
        GameObject enemy = (GameObject)Instantiate(Skeleton,pos, Quaternion.identity);
    }
}
