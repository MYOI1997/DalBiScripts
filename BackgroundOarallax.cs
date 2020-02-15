using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class BackgroundOarallax : MonoBehaviour
{

    private Rigidbody2D Rigidbody;
    private float Speed = -3f;

    [SerializeField]
    private bool IsScrolling;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = new Vector2(0, Speed);
    }

    private void Update()
    {
        if (IsScrolling)
        {
            Rigidbody.velocity = Vector2.zero;
        }
        else
        {
            Rigidbody.velocity = new Vector2(0, Speed);
        }
    }
}
