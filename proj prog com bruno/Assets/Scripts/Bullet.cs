using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float Timer = 5;
    private Rigidbody2D rigidbody2D;
    public AudioSource pasDam;
    public AudioSource gavDam;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = transform.right * Speed;

        Timer = 5;
    }

    void Update()
    {
        Timer -= 1 * Time.deltaTime;
        transform.Rotate(0, 0, -2f);

        if (Timer < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gavDam.Play();
            StartCoroutine(Destruidassa());
        }
        if (other.gameObject.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("EnemyMelee"))
        {
            gavDam.Play();
            StartCoroutine(Destruidassa());
        }
        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Eye"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Destruidassa()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject)
;    }
}
