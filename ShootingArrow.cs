using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.01.29 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class ShootingArrow : MonoBehaviour {

    private Vector3 NextPos;

    public GameObject Arrow;

    [SerializeField]
    private float ShootingSpeed;

    [SerializeField]
    private Transform StartPosition;

    [SerializeField]
    private Transform Destination;

    // Use this for initialization
    void Start()
    {
        NextPos = Destination.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(StartPosition.position == Destination.position)
        {
            Destroy(Arrow);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().Die();
        }
    }

    private void Move()
    {
        StartPosition.localPosition = Vector3.MoveTowards(StartPosition.localPosition, NextPos, ShootingSpeed * Time.deltaTime);
    }
}
