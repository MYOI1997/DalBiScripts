using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class DragonBreath : MonoBehaviour {

    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private Vector3 NextPosition;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    private void OnEnable()
    {
        childTransform.position = new Vector2(-37, -15);
    }

    void Start()
    {
        StartPosition = childTransform.localPosition;
        EndPosition = transformB.localPosition;
        NextPosition = EndPosition;
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerManager>().Die();
        }
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, NextPosition, Speed * Time.deltaTime);
    }
}
