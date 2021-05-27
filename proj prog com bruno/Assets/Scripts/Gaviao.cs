using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaviao : MonoBehaviour
{
    public float speed;
    float lowSpeed;
    float attackCooldown;

    int vida = 2;

    public Transform gaviaoIda;
    public Transform gaviaoVolta;
    public AudioSource attack;

    float randomNum;

    void Start()
    {
        attackCooldown = 0;
        lowSpeed = speed - 2;
        randomNum = UnityEngine.Random.Range(0.21f, 0.24f);
    }

    void Update()
    {
        attackCooldown += Time.deltaTime;
        if(attackCooldown >= 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, gaviaoIda.transform.position, speed * Time.deltaTime);
            StartCoroutine(Tempo());
        }

        if(vida <= 0)
        {
            Destroy(gameObject);
            Score.EnemyPoints += 100;
        }
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(1);
        attackCooldown = 0;

        StartCoroutine(TempoVolta());
    }

    IEnumerator TempoVolta()
    {
        yield return new WaitForSeconds(randomNum);
        transform.position = Vector2.MoveTowards(transform.position, gaviaoVolta.transform.position, lowSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            vida--;
        }
        if (other.gameObject.CompareTag("BulletExplosion") || other.gameObject.CompareTag("Laser"))
        {
            vida -= 2;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            attack.Play();
        }
    }
}
