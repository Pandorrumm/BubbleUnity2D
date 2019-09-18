using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxStartMenu : MonoBehaviour
{
    public Transform mainCameraPosition;


    public float backgroundMoveSpeed;
    private float directionX;


    public float offsetByX = 13f;


    void Update()
    {

        directionX = backgroundMoveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x - directionX, transform.position.y);

        if (transform.position.x - mainCameraPosition.position.x < -offsetByX)
        {
            transform.position = new Vector2(mainCameraPosition.position.x + offsetByX, transform.position.y);
        }
        else if (transform.position.x - mainCameraPosition.position.x > offsetByX)
        {
            transform.position = new Vector2(mainCameraPosition.position.x - offsetByX, transform.position.y);
        }

    }
}
