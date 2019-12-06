using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{ 
    public Transform player;
    public bool isshooting;
    public bool enemydetected;
    public float health = 100f;
    public GameObject patrol;
    public bool isdead = false;
    private bool dead = false;
    public Messaging message;
    public GameObject fireeffect;
    public Transform firepos;
    public float bulletspeed = 200f;
    public RaycastShoot r;
    public OpenGate gate;
    private bool running = false;

    // Update is called once per frame
    void Update()
    {
        float currenthealth = health;
        if (!dead)
        {
            Vector3 direction = player.position - this.transform.position;

            float angle = Vector3.Angle(direction, this.transform.forward);
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.05f);

            if (gate.Gateisopen && direction.magnitude > 10)
            {
                if(!this.GetComponent<NavMeshAgent>().isActiveAndEnabled)
                {
                    this.GetComponent<NavMeshAgent>().enabled = true;
                }
                
                this.GetComponent<Animator>().SetBool("run",true);
                running = true;
                this.transform.Translate(0, 0, 0.2f);
                if(direction.magnitude == 10)
                {
                    running = false;
                }
            }

            else if(health != 100)
            {
                enemydetected = true;
                patrol.SetActive(false);
                this.GetComponent<NavMeshAgent>().enabled = false;
                fire();
            }
            else if (direction.magnitude < 10f && direction.magnitude > 5f)
            { 
                message.Stop();
                if (!running)
                {
                    this.GetComponent<Animator>().Play("Aiming SniperRifle");
                }
                enemydetected = true;
                patrol.SetActive(false);
                this.GetComponent<NavMeshAgent>().enabled = false;
                running = false;
            }
            else if (direction.magnitude < 5f)
            {
                isshooting = true;
                fire();
                enemydetected = true;
                patrol.SetActive(false);
                this.GetComponent<NavMeshAgent>().enabled = false;
                running = false;
            }
            else if (direction.magnitude > 10f)
            {
                enemydetected = false;
                this.GetComponent<NavMeshAgent>().enabled = true;
                patrol.SetActive(true);
            }
            else
            {
                this.GetComponent<Animator>().Play("Idle");
            }
            Die();
        }
        else
        {
            return;
        }
    }

    private void fire()
    {
        r.Raycastfire();
        GameObject bul = (GameObject)Instantiate(fireeffect, firepos.position, Quaternion.identity);
        this.GetComponent<Animator>().Play("Fire SniperRifle");
    }

    private bool CheckPlayerMovement()
    {
        Vector3 move = player.transform.position;
        if((player.transform.position.magnitude - move.magnitude) > 2)
        {
            return true;
        }
        return false;
    }

    public void ReduceHealth()
    {
        health -= 10f;
    }

    private void Die()
    {
        if(health <= 0)
        {
            dead = true;
            this.GetComponent<Animator>().Play("Death");
            Destroy(this.GetComponent<BoxCollider>());
            StartCoroutine(end());
        }
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(3f);
        isdead = true;
        this.GetComponent<Enemy>().enabled = false;
    }
}
