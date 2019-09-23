using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
       // rb2d.mass = 0;
        rb2d.gravityScale = 0;
        Invoke("HeroMass", 3.5f);
    }

   
    void Update()
    {
        if (isDead)
        {
            return;
        }

        //if (!EventSystem.current.IsPointerOverGameObject()) // что бы тач по экрану для пузыря не срабатывал на UI
        //{

        //    if (Input.GetMouseButtonDown(0))  // это для компа
        //    {
        //        rb2d.velocity = Vector2.zero;
        //        rb2d.AddForce(new Vector2(0, upForce));
        //        anim.SetTrigger("Flap");
        //        SoundManager.PlaySound("Jump");
        //    }
        //}
        if (!EventSystem.current.IsPointerOverGameObject()) // что бы тач по экрану для пузыря не срабатывал на UI
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)  // это для телефона
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                SoundManager.PlaySound("Jump");
            }
        }
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

    private void HeroMass()
    {
        //rb2d.mass = 1;
        rb2d.gravityScale = 1;
    }

   

}
