using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float upForce = 200f;
    public bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator anim;
    private Collider2D col2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col2d = GetComponent<Collider2D>();
    }

   
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))  // это для компа
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upForce));
            anim.SetTrigger("Flap");
            SoundManager.PlaySound("Jump");
        }

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)  // это для телефона
        //{
        //    rb2d.velocity = Vector2.zero;
        //    rb2d.AddForce(new Vector2(0, upForce));
        //    anim.SetTrigger("Flap");
        //    SoundManager.PlaySound("Jump");
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "column" || collision.gameObject.tag == "fence")
        {
            isDead = true;
            rb2d.velocity = Vector2.zero;
            anim.SetTrigger("Die");
            GameControl.Instance.Die();
            col2d.isTrigger = true;
            SoundManager.PlaySound("Dead");
        }
    }

}
