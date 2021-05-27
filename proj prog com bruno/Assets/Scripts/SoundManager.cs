using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("SOM")]
    public Transform MainCamera;

    [Header("Esquilo")]
    public AudioClip Tiro;

    public void TiroFunction()
    {
        AudioSource.PlayClipAtPoint(Tiro, new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }

}
