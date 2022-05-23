using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartWriting : MonoBehaviour
{
    public GameObject title; 
    public GameObject healthPlayer;
    public GameObject healthEnemy;
    public void Start()
    {
        Time.timeScale = 0;
    }
     void GetReadyStart()
    {
        Time.timeScale = 1;
        title.SetActive(false);
        healthPlayer.SetActive(true);
        healthEnemy.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetReadyStart();
        }
    }
}
