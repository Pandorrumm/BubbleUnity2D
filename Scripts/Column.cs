using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public GameObject plusScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Hero>() != null)
        {
            GameControl.Instance.Score();
            Instantiate(plusScore,transform.position, Quaternion.identity);
            
        }
    }

}
