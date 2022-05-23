using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    public Transform atackPointTheWorld;
    public float ranger = 0.5f;
    public Animator animatorStand;
    public LayerMask enemyLayer;
    public GameObject Stand;
    void OnDrawGizmos()
    {
        if (atackPointTheWorld == null)
            return;
        Gizmos.DrawWireSphere(atackPointTheWorld.position, ranger);
    }
    public void MUDAAAAA(bool bite)
    {
        if (bite == true)
        {
            animatorStand.SetTrigger("MUDAAA");
            Collider2D[] hitenemy = Physics2D.OverlapCircleAll(atackPointTheWorld.position, ranger, enemyLayer);
            foreach (Collider2D enemy in hitenemy)
            {
                enemy.GetComponent<Jotaro>().Takedamage(100);
            }
            Invoke("AnimationEnd", 0.5f);
        }
    } public void MUDAMUDAMUDA(bool bite)
    {
        if (bite == true)
        {
            animatorStand.SetTrigger("MUDA MUDA MUDA");
            Collider2D[] hitenemy = Physics2D.OverlapCircleAll(atackPointTheWorld.position, ranger, enemyLayer);
            foreach (Collider2D enemy in hitenemy)
            {
                enemy.GetComponent<Jotaro>().TakedamageMuda(500);
            }
            Invoke("AnimationEnd", 9);
        }
    }
    public void AnimationEnd()
    {
        Stand.SetActive(false);
    }
}
