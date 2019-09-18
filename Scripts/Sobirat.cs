using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobirat : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject plusScore;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            GameControl.Instance.Score();
            Destroy(gameObject);
            Instantiate(plusScore, transform.position, Quaternion.identity);
            
        }
    }
}
