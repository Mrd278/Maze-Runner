using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMonster : MonoBehaviour
{
    private Animator anim;
    public Transform player;
    public bool ismonster = true;
    public float enemy_health = 100f;
    public bool isdead = false;
    public bool isboss = false;
    private float attack_distance;
    private float run_speed;
    public GameObject Teleport;
    public GameObject[] spawner;
    public GameObject Deatheffect;
    private float player_dist;
    private float damage_power;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        if (isboss)
        {
            attack_distance = 4f;
            run_speed = 0.2f;
            player_dist = 20f;
            damage_power = 0.5f;
        }
        else
        {
            attack_distance = 2f;
            run_speed = 0.05f;
            player_dist = 30f;
            damage_power = 0.1f;

        }
        spawner = GameObject.FindGameObjectsWithTag("spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if(isdead && isboss)
        {
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }
            Teleport.SetActive(true);
            Instantiate(Deatheffect, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if(enemy_health <= 0)
        {
            isdead = true;
            anim.SetBool("isdead", true);
            StartCoroutine(off_collider());
        }
        if (!isdead)
        {
            
            Vector3 direction = player.position - this.transform.position;
            float angle = Vector3.Angle(direction, this.transform.forward);
            if (Vector3.Distance(player.position, this.transform.position) < player_dist)
            {
                direction = player.position - this.transform.position;
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                anim.SetBool("isidle", false);
                if (direction.magnitude > attack_distance)
                {

                    anim.SetBool("iswalking", true);
                    anim.SetBool("isattacking", false);
                    this.transform.Translate(0, 0, run_speed);
                }
                else
                {
                    anim.SetBool("isattacking", true);
                    anim.SetBool("iswalking", false);
                    player.gameObject.GetComponent<Player_stats>().Reduce_Health(damage_power);
                }
            }
            else
            {
                anim.SetBool("isidle", true);
                anim.SetBool("isattacking", false);
                anim.SetBool("iswalking", false);
            }
        }
        
    }

    public void ReduceHealth()
    {
        enemy_health -= 40;
    }

    IEnumerator off_collider()
    {
        yield return new WaitForSeconds(3);
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
