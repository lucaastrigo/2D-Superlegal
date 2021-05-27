using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] MovePassaro;
    private int RandomPoint;

    void Start()
    {
        waitTime = startWaitTime;
        RandomPoint = UnityEngine.Random.Range(0, MovePassaro.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, MovePassaro[RandomPoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, MovePassaro[RandomPoint].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                RandomPoint = UnityEngine.Random.Range(0, MovePassaro.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
