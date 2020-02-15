using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 드래곤 무빙 스크립트 */

public class MovingBoss : MonoBehaviour {

    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private Vector3 NextPosition;

    private bool Flag = true;

    [SerializeField]
    private float MoveSpeed;

    [SerializeField]
    private Transform ChildTransform;

    [SerializeField]
    private Transform TransformB;

    // Use this for initialization
    void Start()
    {
        MoveSpeed = 3;
        
        EndPosition = TransformB.localPosition;
        NextPosition = EndPosition;

        StartCoroutine("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Flag)
        {
            Move();

            if (ChildTransform.position == TransformB.position)
            {
                Destroy(this);
            }
        }
    }

    private void Move()
    {
        ChildTransform.localPosition = Vector3.MoveTowards(ChildTransform.localPosition, NextPosition, MoveSpeed * Time.deltaTime);
    }

    IEnumerator Wait()
    {
        if (Flag)
        {
            yield return new WaitForSeconds(4.2f);
        }

        Flag = false;
    }
}

