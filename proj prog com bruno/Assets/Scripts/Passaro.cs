using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
{   
    public Transform BulletPosition;
    public GameObject PassaroBullet;
    public Animator animator;

    public float Timer = 2;
    
    public int PassaroVida = 1;

    public bool passaroGold;

    void Start()
    {
        Timer = 0;
    }

    void Update()
    {
        if (passaroGold)
        {
            animator.SetBool("IsGold", true);
            //muda o tiro
            if(PassaroVida <= 0)
            {
                Player.Bullet1 = false;
                if (Player.LaserAtivo)
                {
                    Player.Bullet2 = false;
                }
                else
                {
                    Player.Bullet2 = true;
                }
                Score.EnemyPoints += 75;
            }
        }
        else
        {
            //
        }


        Timer -= 1 * Time.deltaTime;

        PassaroVidaFunction();

        if (Timer <= 0)
        {
            PassaroShoot();
            Timer = 2;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("BulletExplosion") || other.gameObject.CompareTag("Laser"))
        {
            PassaroVida--;
        }
    }

    void PassaroShoot()
    {
        Instantiate(PassaroBullet, BulletPosition.position, BulletPosition.rotation);
    }
    void PassaroVidaFunction()
    {
        if (PassaroVida <= 0)
        {
            Destroy(gameObject);
            if (!passaroGold)
            {
                Score.EnemyPoints += 50;
            }
        }
    }
}
