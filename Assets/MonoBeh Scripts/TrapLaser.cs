using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLaser : MonoBehaviour
{
    public GameObject DioPlayer;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DioPlayer.GetComponent<DioConroller>().damageDio(20);
        }
    }
}
