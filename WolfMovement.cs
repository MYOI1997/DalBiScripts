using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.01.29 수정 */
/* 사용하지 않는 ChangeMovement 코루틴 삭제 */
/* 스크립트 명 변경 */

public class WolfMovement : MonoBehaviour /* 2-1 STAGE */
{
    public float MoveSpeed = 4f;

    bool IsTracing = false;
    GameObject TraceTarget;

    void OnTriggerEnter2D(Collider2D other) 
    {       
        if (other.gameObject.tag == "Player")
        {
            TraceTarget = other.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            IsTracing = true; // 추적 시작 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
     
        if (other.gameObject.tag == "Player")
        {
            IsTracing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().Die();
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        Move();
        Physics2D.IgnoreLayerCollision(9, 10);
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string Direction = "";

        if (IsTracing) //추격 시작했을시
        {
            Vector3 PlayerPos = TraceTarget.transform.position; 

            if (PlayerPos.x < transform.position.x)
            {
                Direction = "Left";
            }
            else if (PlayerPos.x > transform.position.x)
            {
                Direction = "Right";
            }
        }

        if (Direction == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (Direction == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * MoveSpeed * Time.deltaTime;
    }
}