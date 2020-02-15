using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWolf : MonoBehaviour {

    public GameObject wolf;
    public AudioClip wolfHowl;
    public AudioSource WolfHowl;

	// Use this for initialization
	void Start () {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wolf.SetActive(true);
            WolfHowl.clip = wolfHowl;
            WolfHowl.Play();

        }
    }

}
