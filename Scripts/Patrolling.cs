using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{
    public Transform[] waypoint;
    public GameObject soldier;
    public bool ispatrolling;
    public Enemy enemydetect;
    public NavMeshAgent agent;
    public int destination = 0;
    public Enemy enemy;

    private void Start()
    {
        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy.isdead)
        {
            if (!enemydetect.enemydetected)
            {
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    patrol();
                }
            }
            else
            {
                ispatrolling = false;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void patrol()
    {
        ispatrolling = true;
        soldier.GetComponent<Animator>().Play("Walk");
        agent.destination = waypoint[destination].position;
        destination = (destination + 1) % waypoint.Length;
    }
}
