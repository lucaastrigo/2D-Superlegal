using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioScroll : MonoBehaviour
{
    float Speed = 10f;
    Vector2 Pos;

    void Start()
    {
        Pos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * Speed, 60);
        transform.position = Pos + Vector2.left * newPos;
    }
}
