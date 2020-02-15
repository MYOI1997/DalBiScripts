using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 현재 사용하지 않으므로, 최종 수정 후 삭제하기 */

public class FallingArrow : MonoBehaviour {

    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private Vector3 NextPosition;

    [SerializeField]
    private float ArrowSpeed;

    [SerializeField]
    private Transform ChildTransform;

    [SerializeField]
    private Transform TransformB;

    // Use this for initialization
    void Start()
    {
        StartPosition = ChildTransform.localPosition;
        EndPosition = TransformB.localPosition;
        NextPosition = EndPosition;
    }

    void Update()
    {
        Move();

        if (ChildTransform.position == TransformB.position)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().Die();
        }
    }

    private void Move()
    {
        ChildTransform.localPosition = Vector3.MoveTowards(ChildTransform.localPosition, NextPosition, ArrowSpeed * Time.deltaTime);
    }
}
