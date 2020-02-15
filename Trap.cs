using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 중복문 간소화 */

public class Trap : MonoBehaviour {

    private PlayerManager PM;

    private void Start()
    {
        PM = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "FallingTrap")
        {
            if (collision.gameObject.tag == "Player" && PM.Alive) 
            {
                PM.Die();
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Ground") 
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     
    {
        if(collision.tag == "Player")
        {
            if(this.gameObject.tag == "FallingTrap")
            {
                if (PM.Alive)
                {
                    gameObject.AddComponent<Rigidbody2D>();
                    Rigidbody2D trapRigid = GetComponent<Rigidbody2D>();
    
                    trapRigid.constraints = RigidbodyConstraints2D.FreezeRotation; 
                }
            }
            else if(gameObject.tag == "FixedTrap")
            {
                if (PM.Alive)
                {
                    PM.Die();
                    Destroy(this);
                }  
            }
        }
    }
}
