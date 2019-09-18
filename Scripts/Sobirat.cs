using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobirat : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject plusScore;

    private Vector2 objectInsertPositionPuzir;
    private PuzirInsert puzirInsert;

    public float columnYMin = -2f;
    public float columnYMax = 2f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        puzirInsert = FindObjectOfType<PuzirInsert>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            GameControl.Instance.Score();
            SoundManager.PlaySound("Score");
            Destroy(gameObject);
            float spawnXPos = 13f;
            float spawnYPos = Random.Range(columnYMin, columnYMax);
            objectInsertPositionPuzir = new Vector2(spawnXPos, spawnYPos);

            Instantiate(puzirInsert.puzirPrefab, objectInsertPositionPuzir, Quaternion.identity);

            Instantiate(plusScore, transform.position, Quaternion.identity);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "deadPuzir")
        {
            Destroy(gameObject);
            Instantiate(puzirInsert.puzirPrefab, objectInsertPositionPuzir, Quaternion.identity);
        }
    }
}
