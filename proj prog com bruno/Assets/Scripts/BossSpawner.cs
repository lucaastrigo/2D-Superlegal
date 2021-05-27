using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;

    int enemiesLeft;
    int meleeEnemiesLeft;
    int bossesLeft;
    float toSpawn = 84;
    GameObject[] enemies;
    GameObject[] meleeEnemies;
    GameObject[] bosses;

    void Update()
    {
        //if there is no enemies alive, spawn boss

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        meleeEnemies = GameObject.FindGameObjectsWithTag("EnemyMelee");
        bosses = GameObject.FindGameObjectsWithTag("Boss");

        enemiesLeft = enemies.Length;
        meleeEnemiesLeft = meleeEnemies.Length;
        bossesLeft = bosses.Length;

        toSpawn -= Time.deltaTime;

        if(toSpawn <= 0)
        {
            if (enemiesLeft == 0 && meleeEnemiesLeft == 0 && bossesLeft == 0)
            {
                Instantiate(boss, transform.position, Quaternion.identity);
            }
        }
    }
}
