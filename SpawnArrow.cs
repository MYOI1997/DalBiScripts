using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.01.29 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class SpawnArrow : MonoBehaviour {

    public AudioClip ArrowClip;
    private AudioSource ArrowSound;

    void Awake()
    {
        ArrowSound = GameObject.Find("ArrowSound").GetComponent<AudioSource>();
        ArrowSound.clip = ArrowClip;
    }

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            ArrowSound.Play();

            float randomY = Random.Range(-8f, -6f);
            GameObject newArrow = Instantiate(Resources.Load("Prefabs/Arrow"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newArrow.transform.parent = null;
            newArrow.transform.localPosition = Vector3.zero;
            newArrow.transform.position = new Vector3(100, randomY, 0f);

            yield return new WaitForSeconds(4f);
        }
    }



}
