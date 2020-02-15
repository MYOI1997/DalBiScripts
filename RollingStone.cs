using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : MonoBehaviour
{
    public GameObject Stone;

    public AudioClip StoneClip;
    public AudioSource StoneSoundSource;

    void Start()
    {
        StoneSoundSource.clip = StoneClip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Stone.SetActive(true);
            StoneSoundSource.Play();
        }
    }
}
