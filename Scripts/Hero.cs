using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float upForce = 200f;
    public bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator anim;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        }

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)  // это для телефона
        //{
        //    rb2d.velocity = Vector2.zero;
        //    rb2d.AddForce(new Vector2(0, upForce));
        //    anim.SetTrigger("Flap");
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
        }
    }

}
