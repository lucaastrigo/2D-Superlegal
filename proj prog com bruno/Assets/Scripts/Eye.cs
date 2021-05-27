using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eye : MonoBehaviour
{
    GameObject boss;
    int life = 30;
    public static string state;
    public AudioSource damagedSound;


    public HealthBar healthBar;
    private int currentHealth;

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        healthBar.SetMaxHealth(life);
        
    }

    private void Update()
    {
        currentHealth = life;
        healthBar.SetHealth(currentHealth);

        if (life <= 30 && life > 17)
        {
            state = "st";
        }
        if(life <= 17 && life > 12)
        {
            state = "nd";
        }
        if(life <= 12 && life > 0)
        {
            state = "rd";
        }
        if (life <= 0)
        {
            Destroy(boss);
            Score.EnemyPoints += 1000;
            SceneManager.LoadScene("Vitoria");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("BulletExplosion"))
        {
            life--;
            currentHealth--;
            damagedSound.Play();
        }
    }
}
