using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.01.29 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class WolfMovement2 : MonoBehaviour /* 2-2 STAGE */
{
    Rigidbody2D RigidBody;

    float DirX;

    GameObject TraceTarget;
    float MoveSpeed = 11f;

    SpriteRenderer Renderer;
    bool IsJump = false;

    // Use this for initialization
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        TraceTarget = GameObject.FindGameObjectWithTag("Player");
        if (transform.position.x < TraceTarget.transform.position.x)
        {
            Renderer.flipX = true;
            DirX = 0.5f;
        }

        else if (transform.position.x > TraceTarget.transform.position.x)
        {
            Renderer.flipX = false;
            DirX = -0.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().Die();
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        RigidBody.velocity = new Vector2(DirX * MoveSpeed, RigidBody.velocity.y);
        Physics2D.IgnoreLayerCollision(9, 10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsJump == false && other.gameObject.tag == "JumpPosition")
        {
            IsJump = true;
            RigidBody.AddForce(new Vector2(4, 7), ForceMode2D.Impulse);
            Invoke("Destroy", 15f);
        }
    }

    void Destroy()
    {
        Destroy(this);
    }
}
