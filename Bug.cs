using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* Move함수 간소화 */

public class Bug : MonoBehaviour
{
    public float MoveSpeed = 3f;

    public AudioSource IdleSource;
    public AudioSource DeadSource;
    public AudioSource BoomSource;

    public AudioClip IdleClip;
    public AudioClip DeadClip;
    public AudioClip BoomClip;

    Animator BugAnimator;
    int MovementFlag = 0;
    GameObject TraceTarget;

    private bool IsMove =true;

    void Awake()
    {
        BoomSource.clip = BoomClip;
        DeadSource.clip = DeadClip;
        IdleSource.clip = IdleClip;
    }

    void Start()
    {
        IdleSource.loop = true;
        IdleSource.Play();

        BugAnimator = gameObject.GetComponent<Animator>();
        StartCoroutine("ChangeMovement");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsMove = false;
            TraceTarget = other.gameObject;
            StopCoroutine("ChangeMovement");
            BugAnimator.SetBool("isBoom", true);
            BoomSource.Play();
            DeadSource.Play();
            Invoke("Wait", 1.5f);
        }
    }

    IEnumerator ChangeMovement()
    {
        MovementFlag = Random.Range(1, 3);

        yield return new WaitForSeconds(1.5f);
        StartCoroutine("ChangeMovement");
    }
    
    void FixedUpdate()
    {
        if (IsMove == true)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (MovementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (MovementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * MoveSpeed * Time.deltaTime;
    }

    void Wait()
    {
        if(Vector3.Distance(TraceTarget.transform.position, transform.position) <= 3.5f)
        {
            TraceTarget.gameObject.GetComponent<PlayerManager>().Die();
        }

        Destroy(gameObject);
    }
}
