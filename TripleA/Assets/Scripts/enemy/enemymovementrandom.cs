using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovementrandom : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public BoxCollider2D lanterna;

    public Transform[] moveSpots;
    private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = UnityEngine.Random.Range(0, moveSpots.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <=0)
            {
                randomSpot = UnityEngine.Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
    }
    public void OnTriggerEnter2D(Collider2D lanterna)
    {
        if (lanterna.CompareTag("Player") && !lanterna.isTrigger)
        {
            Debug.Log("Ola");
        }
    }
}
