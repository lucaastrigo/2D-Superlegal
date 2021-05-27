using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    void Update()
    {
        if (Player.LaserAtivo)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if(!Player.LaserAtivo)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
