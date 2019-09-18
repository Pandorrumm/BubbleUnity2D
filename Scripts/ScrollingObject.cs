using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.Instance.scrollSpeed, 0);
    }

   
    void Update()
    {
        if(GameControl.Instance.isGameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
