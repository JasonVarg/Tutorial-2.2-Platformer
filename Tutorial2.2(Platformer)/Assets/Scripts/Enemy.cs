using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform startM;
    public Transform endM;

    /*
    public float speed = 1.0f;

    private float startTime;
    private float journeyLength;
    */

    void Start()
    {
        /* 
        startTime = Time.time;

        journeyLength = Vector2.Distance(endM.position, startM.position);
        */
    }

    void Update()
    {
        /*
        float distCovered = (Time.time - startTime) * speed;

        float fracJourney = distCovered / journeyLength;

        transform.position = Vector2.Lerp(startM.position, endM.position, fracJourney);
        */
    }
}
