using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class MushJump : MonoBehaviour
{

    private PlayerManager PM;
    private Rigidbody2D TargetRigidBody;
    private Animator TargetAnimator;

    // Use this for initialization
    void Start()
    {
        PM = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        TargetRigidBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        TargetAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (TargetRigidBody.velocity.y < 0)
            {
                TargetRigidBody.velocity = new Vector2(0, 0);
                Vector2 mushJumpVelocity = new Vector2(0, PM.JumpPower * 1.5f);
                TargetRigidBody.AddForce(mushJumpVelocity, ForceMode2D.Impulse);
                TargetAnimator.SetBool("Jump", false);
                TargetAnimator.SetBool("DoubleJump", false);
                TargetAnimator.SetBool("MushJump", true);
            }
        }
    }
}
