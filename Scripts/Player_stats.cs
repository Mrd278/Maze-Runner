using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player_stats : MonoBehaviour
{
    public float Player_Health = 100f;
    public int Total_points = 0;
    public Text health_text;
    public Text Score_text;
    public Text Final_Score_text;
    public GameObject GameOverUi;
    public GameObject GamePanel;
    public Text wint_Score;
    public Text pause_Score;
    public FirstPersonController controller;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Reduce_Health(float damage)
    {
        Player_Health -= damage;
    }

    private void Update()
    {
        int c = 0;
        if(Player_Health <= 0)
        {
            controller.m_MouseLook.m_cursorIsLocked = false;
            GameOverUi.SetActive(true);
            GamePanel.SetActive(false);
            Time.timeScale = 0f;
        }
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemy.Length; i++)
        {
            if(enemy[i].GetComponent<SkeletonMonster>().isdead)
            {
                c++;
            }
        }
        Total_points = c * 10;
        int h = (int)Player_Health;
        health_text.text = h.ToString();
        Score_text.text = Total_points.ToString();
        Final_Score_text.text = Total_points.ToString();
        wint_Score.text = Total_points.ToString();
        pause_Score.text = Total_points.ToString();
    }
}
