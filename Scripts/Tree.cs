using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float spawnRate = 7f; //Скорость появления
    public int columnInsertSize = 1;  //сколько раз будет вставка 
    public float columnYMin = -2f;
    public float columnYMax = 2f;

    private float timeSinceLastSpawn; //время с последнего появления
    private float spawnXPos = 13f;
    private int currentColumn = 0;

    public GameObject treePrefab;

    private GameObject[] tree;
    private Vector2 objectInsertPosition = new Vector2(5, -25f);


    void Start()
    {
        tree = new GameObject[columnInsertSize];
        for (int i = 0; i < columnInsertSize; i++)
        {
            tree[i] = (GameObject)Instantiate(treePrefab, objectInsertPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;

            float spawnYPos = Random.Range(columnYMin, columnYMax);
            tree[currentColumn].transform.position = new Vector2(spawnXPos+10, spawnYPos);

            currentColumn++;

            if (currentColumn >= columnInsertSize)
            {
                currentColumn = 0;
            }
        }
    }
}
