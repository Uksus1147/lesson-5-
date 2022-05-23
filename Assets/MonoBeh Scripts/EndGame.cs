using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    public GameObject Winner;
    public GameObject looser;
    public GameObject JotaroBar;
    public GameObject DioBar;
    public GameObject DioPlayer;
    public GameObject JotaroEnemy;
    //void Update()
    //{
    //    if (DioHealth <= 0)
    //    {
    //        Time.timeScale = 0;
    //        looser.SetActive(true);
    //    }
    //    else if (JotaroHealth <= 0)
    //    {
    //        Time.timeScale = 0;
    //        Winner.SetActive(true);
    //    }
    //}
    public void JotaroWin(bool lose)
    {
        if (lose == true)
        {
            Time.timeScale = 0;
            looser.SetActive(true);
            JotaroBar.SetActive(false);
            DioBar.SetActive(false);
            DioPlayer.SetActive(false);
            JotaroEnemy.SetActive(false);
        }
    }
    public void DioWin(bool win)
    {
        if (win == true)
        {
            Time.timeScale = 0;
            Winner.SetActive(true);
            JotaroBar.SetActive(false);
            DioBar.SetActive(false);
            DioPlayer.SetActive(false);
            JotaroEnemy.SetActive(false);
        }
    }
    public void Restart(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
