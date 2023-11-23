using PlatForm.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float hp;
    private float hpMin = 0;
    public float hpMax;
    public bool onChangeHP;
    public bool onDie;


    private void Start()
    {
        hp = hpMax;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnDamage();
            Invoke("OffDamage", 3);
        }
    }

    private void OnDamage()
    {
        if (hp > 0)
            hp -= 100;
        if (hp == 0 || hp < 0)
        {
            hp = 0;
            OnDie();
        }
        onChangeHP = true;
        gameObject.layer = 11;
        //spriteRenderer.color = new Color(1, 1, 1, 0.4f);
    }

    private void OffDamage()
    {
        gameObject.layer = 10;
        //spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    private void OnDie()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
        //onDie = true;
    }







}
