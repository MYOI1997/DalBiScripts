using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.01.29 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class SlimeMovement : MonoBehaviour /* Slime */
{
    private Vector2 JumpPower;
    Rigidbody2D RigidBody;

    void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    { 
        StartCoroutine(Jump());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().Die();
        }
    }

    IEnumerator Jump()
    {      
        yield return new WaitForSeconds(Random.Range(1, 6));

        JumpPower = new Vector2(0, 9);
        RigidBody.velocity = new Vector2(0, 0);
        RigidBody.AddForce(JumpPower, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Jump());
    }
}
