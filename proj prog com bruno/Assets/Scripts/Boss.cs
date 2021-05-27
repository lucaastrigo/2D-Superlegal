using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float featherCooldown;
    public float laserCooldown;
    public AudioSource featherSound;
    public Transform featherPoint1;
    public Transform featherPoint2;
    public GameObject feather;
    public GameObject laser;
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        featherCooldown = 6;
        laserCooldown = 9;
        animator.SetTrigger("Coruja1");

        laser.SetActive(false);
    }

    void Update()
    {
        if(Eye.state == "st")
        {
            featherCooldown -= Time.deltaTime;
            if (featherCooldown <= 0)
            {
                featherSound.Play();
                Instantiate(feather, featherPoint1.position, Quaternion.identity);
                Instantiate(feather, featherPoint2.position, Quaternion.identity);
                featherCooldown = 6;
            }
        }

        if(Eye.state == "nd")
        {
            laserCooldown -= Time.deltaTime;
            animator.SetTrigger("Coruja2");

            if (laserCooldown <= 0)
            {
                laser.SetActive(true);

                if (laserCooldown <= -3)
                {
                    laser.SetActive(false);
                    laserCooldown = 3;
                }
            }
            else
            {
                laser.SetActive(false);
            }
        }

        if(Eye.state == "rd")
        {
            featherCooldown -= Time.deltaTime;
            laserCooldown -= Time.deltaTime;
            animator.SetTrigger("Coruja3");
            if (featherCooldown <= 0)
            {
                featherSound.Play();
                Instantiate(feather, featherPoint1.position, Quaternion.identity);
                Instantiate(feather, featherPoint2.position, Quaternion.identity);
                featherCooldown = 6;
            }

            if (laserCooldown <= 0)
            {
                laser.SetActive(true);

                if (laserCooldown <= -3)
                {
                    laser.SetActive(false);
                    laserCooldown = 3;
                }
            }
            else
            {
                laser.SetActive(false);
            }
        }
    }
}
