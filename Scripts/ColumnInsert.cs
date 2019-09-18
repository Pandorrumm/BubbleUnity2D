using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnInsert : MonoBehaviour
{

    public float spawnRate = 6f; //Скорость появления
    public int columnInsertSize = 5;  //сколько раз будет вставка колон
    public float columnYMin = -2f;
    public float columnYMax = 2f;

    private float timeSinceLastSpawn; //время с последнего появления
    private float spawnXPos = 10f;
    private int currentColumn = 0;

    public GameObject [] columnPrefab;

    private GameObject[] columns;
    
    private Vector2 objectInsertPosition = new Vector2(10, -35f);


    void Start()
    {
        columns = new GameObject[columnInsertSize];
        
        for (int i = 0; i < columnInsertSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab[Random.Range(0, columnPrefab.Length)], objectInsertPosition, Quaternion.identity);
           
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;

            float spawnYPos = Random.Range(columnYMin, columnYMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPos, spawnYPos);
            
            currentColumn++;

            if( currentColumn >= columnInsertSize)
            {
                currentColumn = 0;
            }
        }
    }
}
