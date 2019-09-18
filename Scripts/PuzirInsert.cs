using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzirInsert : MonoBehaviour
{

    public float spawnRate = 5f; //Скорость появления
    public int columnInsertSize = 15;  //сколько раз будет вставка колон
    public float columnYMin = -2f;
    public float columnYMax = 2f;

    private float timeSinceLastSpawn; //время с последнего появления
    private float spawnXPos = 13f;
    private int currentColumn = 0;

    public GameObject puzirPrefab;

    private GameObject[] puzir;
    private Vector2 objectInsertPosition = new Vector2(10, -25f);


    void Start()
    {
        puzir = new GameObject[columnInsertSize];
        for (int i = 0; i < columnInsertSize; i++)
        {           
            puzir[i] = (GameObject)Instantiate(puzirPrefab, objectInsertPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;

            float spawnYPos = Random.Range(columnYMin, columnYMax);
            puzir[currentColumn].transform.position = new Vector2(spawnXPos, spawnYPos);

            currentColumn++;

            if (currentColumn >= columnInsertSize)
            {
                currentColumn = 0;
            }
        }
    }
}
