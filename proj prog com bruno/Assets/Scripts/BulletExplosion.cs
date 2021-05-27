using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public Animator animator;
    public AudioSource gavDam;


    public float Speed;
    public float Timer = 5;
    

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = transform.right * Speed;

        Timer = 5;
    }

    void Update()
    {
        Timer -= 1 * Time.deltaTime;

        if (Timer < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyMelee") || other.gameObject.CompareTag("Eye"))
        {
            GetComponent<CircleCollider2D>().enabled = true;
            gavDam.Play();
            animator.SetTrigger("isExploding");
            StartCoroutine(DestroyBulletExplosion());
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        if (other.gameObject.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyBulletExplosion()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
