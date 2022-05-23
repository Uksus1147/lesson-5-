using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JotaroSurv : MonoBehaviour
{
    public float ranger = 0.5f;
    public Transform attackPoint;
    public float speedEnemy;
    Transform player;
    public Transform _enemy;
    public bool GoTo = true;
    public Animator animEnemy;
    private bool racingface = true;
    public LayerMask enemyLayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if(GoTo == true)
        {
            Go();
            animEnemy.SetTrigger("Walk");
        }
        
        if (racingface == false  && player.position.x < _enemy.position.x )
        {
            Flip();
        }
        else if (racingface == true && player.position.x > _enemy.position.x)
        {
            Flip();
        }
    }
    void Flip()
    {
        racingface = !racingface;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void Go()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speedEnemy * Time.deltaTime);
    }
    public void Attack()
    {
        animEnemy.SetTrigger("attack");
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackPoint.position, ranger, enemyLayer);
        foreach (Collider2D enemy in hitenemy)
        {
            enemy.GetComponent<DioConroller>().damageDio(20);
        }
    }
    void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, ranger);
    }
}
