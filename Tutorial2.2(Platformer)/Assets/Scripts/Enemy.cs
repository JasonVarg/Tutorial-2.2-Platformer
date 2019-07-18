using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Vector2 enemyPos;
    private float xPos, yPos;
    private float increaseX;

    void Awake()
    {
        increaseX = (2.0f * Mathf.PI) / 3.0f;
    }

    void Update()
    {
        enemyPos = new Vector2(2.0f * Mathf.Sin(xPos), transform.position.y);
        transform.Rotate (new Vector3(0, 0, 45)* Time.deltaTime);
    }
}
