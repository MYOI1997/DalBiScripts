using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

/* 기존의 늑대 함수와 합치는게 좋을까? */

public class DestroyWolf : MonoBehaviour {

    public GameObject TargetWolf;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TargetWolf.SetActive(false);
            Destroy(TargetWolf);
        }
    }
}
