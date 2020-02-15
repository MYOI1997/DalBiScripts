using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class PlatformMovement : MonoBehaviour {

    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private Vector3 NextPosition;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

	void Start ()
    {
        StartPosition = childTransform.localPosition;
        EndPosition = transformB.localPosition;
        NextPosition = EndPosition;  
	}

	void Update ()
    {
        Move();	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
            collision.gameObject.GetComponent<PlayerManager>().JumpPower = 8f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.parent = null;
            collision.gameObject.GetComponent<PlayerManager>().JumpPower = 6.5f;
        }
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, NextPosition, Speed * Time.deltaTime);

        if(Vector3.Distance(childTransform.localPosition, NextPosition) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        NextPosition = NextPosition != StartPosition ? StartPosition : EndPosition;
    }
}
