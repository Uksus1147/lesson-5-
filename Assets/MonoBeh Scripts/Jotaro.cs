using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jotaro : MonoBehaviour
{
    public float maxHealth = 1000;
    public float currentHealth;
    public Animator animator;
    public GameObject banner;
    public float fillEnemy;
    public Image BarEnemy;
    public GameObject healthEnemy;
    public GameObject JotaroS;
    private void Start()
    {
        currentHealth = maxHealth;
        fillEnemy = 1f;
    }
    private void Update()
    {
        BarEnemy.fillAmount = fillEnemy;
    }
    public void Takedamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        fillEnemy = fillEnemy - (damage / 1000);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void TakedamageMuda(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("HurtUltimayte");
        fillEnemy = fillEnemy - (damage / 1000);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void EndAnimation()
    {
        if (currentHealth <= 0)
        {
            banner.GetComponent<EndGame>().DioWin(true);
        }
    }
    void Die()
    {
        animator.SetBool("IsDie", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        healthEnemy.SetActive(false);
    }
    public void InStopTime(bool JotaroStop)
    {
        if (JotaroStop ==true)
        {
            //this.enabled = false;
            //Debug.Log("Thats Ok, it's worked");
            animator.speed = 0;
            JotaroS.GetComponent<JotaroSurv>().GoTo = false;


        }
        else if( JotaroStop == false)
        {
            animator.speed = 1;
            JotaroS.GetComponent<JotaroSurv>().GoTo = true;
        }
    }
}
