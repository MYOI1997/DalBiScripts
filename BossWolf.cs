using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class BossWolf : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public int HP = 15;

    Animator BossAnimator;

    int MovementFlag = 0;
    bool IsTracing = false;

    GameObject TraceTarget;
    public GameObject Portal;

    public AudioSource HowlingSource;
    public AudioClip HowlingClip;

    List<bool> BossEffectHp = new List<bool> { false, false };

    void Start()
    {
        HowlingSource.clip = HowlingClip;
        BossAnimator = gameObject.GetComponent<Animator>();
        StartCoroutine("HowlingStart");
        StartCoroutine("ChangeMovement");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TraceTarget = other.gameObject;
            StopCoroutine("ChangeMovement");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            IsTracing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            IsTracing = false;
            StartCoroutine("ChangeMovement");
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

    IEnumerator ChangeMovement()
    {
        MovementFlag = Random.Range(1, 3);

        yield return new WaitForSeconds(3f); 
        StartCoroutine("ChangeMovement");
    }

    void FixedUpdate()
    {
        if(BossAnimator.GetBool("IsHowling") == false)
        {
            Move();
        }
       
        Physics2D.IgnoreLayerCollision(9, 10);

        if (HP == 13 && BossEffectHp[0] == false)
        {
            StartCoroutine("HowlingStart");
            BossEffectHp[0] = true;
        }

        if (HP == 6 && BossEffectHp[1] == false)
        {
            StartCoroutine("HowlingStart");
            BossEffectHp[1] = true;
        }

        if (HP == 0)
        {
            Destroy(gameObject);
            Portal.SetActive(true);
        }
    }

    void Move()
    {
        Vector3 MoveVelocity = Vector3.zero;
        string Dist = "";

        if (IsTracing)
        {
            Vector3 playerPos = TraceTarget.transform.position;

            if (playerPos.x < transform.position.x)
            {
                Dist = "Left";
            }
            else if (playerPos.x > transform.position.x)
            {
                Dist = "Right";
            }
        }
        else
        {
            if (MovementFlag == 1)
            {
                Dist = "Left";
            }
            else if (MovementFlag == 2)
            {
                Dist = "Right";
            }
        }

        if (Dist == "Left")
        {
            BossAnimator.SetBool("IsMoving", true);
            MoveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (Dist == "Right")
        {
            BossAnimator.SetBool("IsMoving", true);
            MoveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += MoveVelocity * MoveSpeed * Time.deltaTime;
    }

    IEnumerator HowlingStart()
    {
        BossAnimator.SetBool("IsHowling", true);
        HowlingSource.Play();
        yield return new WaitForSeconds(4f);
        BossAnimator.SetBool("IsHowling", false);
    }
}
