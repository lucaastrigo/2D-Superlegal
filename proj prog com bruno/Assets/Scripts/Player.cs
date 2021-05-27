using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;
    float invulneravelTime;

    public float speed;    
    public float Timer = 0.5f;
    public static float timinhoEspecial = 30;

    public Animator animator;
    public static int EsquiloVida;
    public int EsquiloVidaNum;

    public static bool Bullet1;
    public static bool Bullet2;
    public static bool LaserAtivo;

    public Image[] VidaImage;
    public Sprite Vida0;
    public Sprite Vida1;

    public Transform BulletPosition;
    public GameObject Bullet;
    public GameObject BulletExplosion;

    Rigidbody2D rb;

    void Start()
    {
        Timer = 0;
        rb = GetComponent<Rigidbody2D>();
        EsquiloVida = 3;

        Bullet1 = true;
        Bullet2 = false;
        LaserAtivo = false;
    }

    void FixedUpdate()
    {       
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if(!Bullet2 && !LaserAtivo)
        {
            Bullet1 = true;
        }


        Timer -= 1 * Time.deltaTime;

        if(EsquiloVida > EsquiloVidaNum)
        {
            EsquiloVida = EsquiloVidaNum;
        }

        for (int i = 0; i < VidaImage.Length; i++)
        {
            if(i < EsquiloVida)
            {
                VidaImage[i].sprite = Vida1;
            }
            else
            {
                VidaImage[i].sprite = Vida0;
            }
            if(i < EsquiloVidaNum)
            {
                VidaImage[i].enabled = true;
            }
            else
            {
                VidaImage[i].enabled = false;
            }
        }

        if ((Timer <= 0) && Input.GetKey("space"))
        {
            Shoot();
            animator.SetBool("IsAtirando", true);
            Timer = 0.5f;
        }
        if (Input.GetKeyUp("space"))
        {
            animator.SetBool("IsAtirando", false);
        }


        if (Bullet2)
        {
            StartCoroutine(TempoDePoderBullet2());
        }
        if (LaserAtivo)
        {
            StartCoroutine(TempoDePoderLaser());
        }


        if(moveHorizontal > 0) 
        {
            transform.Rotate(0, 0, -0.1f);

            if(transform.rotation.z <= -0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, -10);
            }
        }


        if(moveHorizontal == 0)
        {
            if (transform.rotation.z > -0.1f && transform.rotation.z < 0)
            {
                transform.Rotate(0, 0, 0.1f);

                if(transform.rotation.z >= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }

            if (transform.rotation.z < 0.1f && transform.rotation.z > 0)
            {
                transform.Rotate(0, 0, -0.1f);

                if (transform.rotation.z <= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }

        if (moveHorizontal < 0)
        {
            transform.Rotate(0, 0, 0.1f);

            if (transform.rotation.z >= 0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 10);
            }
        }

        if (EsquiloVida <= 0)
        {
            EsquiloVidaFunction();
            StartCoroutine(Restart());
        }

        invulneravelTime -= Time.deltaTime;
        if(invulneravelTime > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            Physics2D.IgnoreLayerCollision(9, 10);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 10, false);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }


    void Shoot()
    {
        if (Bullet1 == true)
        {
            Instantiate(Bullet, BulletPosition.position, BulletPosition.rotation);
        }
        if (Bullet2 == true)
        {
            Instantiate(BulletExplosion, BulletPosition.position, BulletPosition.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("EnemyMelee") || other.gameObject.CompareTag("Laser"))
        {
            if(invulneravelTime > 0)
            {
                EsquiloVida *= 1;
            }
            else
            {
                EsquiloVida -- ;
                invulneravelTime = 2;
            }
        }

        if (other.gameObject.CompareTag("LaserPowerUp"))
        {
            Bullet1 = false;
            Bullet2 = false;
            LaserAtivo = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("VidaPowerUp"))
        {
            EsquiloVida += 1;
            Destroy(other.gameObject);
        }
    }

    void EsquiloVidaFunction()
    {
        if (EsquiloVida <= 0)
        {
            //SoundScript.Instance.EsquiloMorteSound();
            gameObject.GetComponent<Player>().enabled = false;
        }
    }

    IEnumerator TempoDePoderLaser()
    {
        yield return new WaitForSeconds(7.5f);
        LaserAtivo = false;
    }
    IEnumerator TempoDePoderBullet2()
    {
        yield return new WaitForSeconds(7.5f);
        Bullet2 = false;
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        Score.EnemyPoints = 0;
        SceneManager.LoadScene("SampleScene");
    }
}
