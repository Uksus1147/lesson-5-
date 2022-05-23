using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DioConroller : MonoBehaviour
{
    public float MaxHealth = 100;
    public float Health;
    public float speed;
    public float jumpForce;
    public float moveInput;
    private Rigidbody2D rb;
    private bool racingface = true;
    private bool idGround;
    public Transform feetPose;
    public bool IsLayerMask;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Animator anim;
    public GameObject BannerEnd;
    public Image Bar;
    public float fill;
    public GameObject healthPlayer;
    public Transform PlayerPosition;
    public void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Health = MaxHealth;
        fill = 1f;
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (racingface == false && moveInput > 0)
        {
            Flip();
        }
        else if (racingface == true && moveInput < 0)
        {
            Flip();
        }
        if (moveInput == 0)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && racingface == false)
        {
            PlayerPosition.position = new Vector2(PlayerPosition.position.x - 3, PlayerPosition.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && racingface == true)
        {
            PlayerPosition.position = new Vector2(PlayerPosition.position.x + 3, PlayerPosition.position.y);
        }
    }

    private void Update()
    {
        Bar.fillAmount = fill;
        idGround = Physics2D.OverlapCircle(feetPose.position, checkRadius, whatIsGround);
        if(idGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("take off");
        }
        if (idGround == true)
        {
            anim.SetBool("IsJumping", false);
        }
        else if (idGround == false)
        {
            anim.SetBool("IsJumping", true);

        }
    }
    void Flip()
    {
        racingface = !racingface;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void damageDio(float DamageForPlayer)
    {
        Health -= DamageForPlayer;
        anim.SetTrigger("DioHurt");
        fill = fill - (DamageForPlayer / 100);

        if (Health <= 0)
        {
            DioDie();
        }
    }
    void DioDie()
    {
        anim.SetBool("DioIsDie", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        healthPlayer.SetActive(false);
    }
    public void EndAnim()
    {
        if (Health <= 0)
        {
            BannerEnd.GetComponent<EndGame>().JotaroWin(true);
        }
    }
}
