using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaroBullet : MonoBehaviour
{
    public float Speed;
    public float Timer = 5;
    private Rigidbody2D rigidbody2D;
    float randf;
    public bool rot;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = transform.right * Speed;

        Timer = 5;
        randf = UnityEngine.Random.Range(0.5f, 2);
    }

    void Update()
    {
        Timer -= 1 * Time.deltaTime;

        if (rot)
        {
            transform.Rotate(0, 0, -randf);
        }

        if (Timer < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
    }
}
