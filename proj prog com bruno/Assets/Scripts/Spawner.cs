using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Spawn;
    public Transform SpawnPosition;

    public float timer;
    public float timerr;
    public float timeUntilStopSpawning;
    public bool spawnForever;

    void Update()
    {
        timeUntilStopSpawning -= Time.deltaTime;

        if (timer >= timerr)
        {
            Instantiate(Spawn, SpawnPosition.position, SpawnPosition.rotation);
            timer = 0f;
        }

        if (!spawnForever)
        {
            if (timeUntilStopSpawning <= 0)
            {
                timer = 0;
            }
            else
            {
                timer += 1 * Time.deltaTime;
            }
        }
        else
        {
            timer += 1 * Time.deltaTime;
            timeUntilStopSpawning = 0;
        }
    }
}
