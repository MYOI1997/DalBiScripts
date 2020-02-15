using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class JumpItem : MonoBehaviour {

    private PlayerManager PM;

    private void Start()
    {
        PM = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && PM.Alive)
        {
            PM.MaxJumpCount = 2;
            PM.JumpCount = 2;
            Destroy(gameObject);
        }
    }
}
