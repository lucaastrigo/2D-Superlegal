using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void Start()
    {
        //
    }

    void Update()
    {
        if(Player.EsquiloVida <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-0.6f, -0.15f) * 50);
            transform.Rotate(0, 0, 1);
        }
    }
}
