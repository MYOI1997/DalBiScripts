using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class HomingMissile : MonoBehaviour {

    public GameObject Target;

    public float MissileSpeed = 5f;
    public float RotateSpeed = 100f;

    private Rigidbody2D RigidBody;

    void Start()
    {
        gameObject.layer = 9;
                
        Physics2D.IgnoreLayerCollision(11, 12);
        Physics2D.IgnoreLayerCollision(9, 12);

        RigidBody = GetComponent<Rigidbody2D>();
        Target = GameObject.FindWithTag("Wolfboss").gameObject;
    }

    void Update()
    {
        if(gameObject.layer == 12)
        {
            Physics2D.IgnoreLayerCollision(11,12);
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Homing());
            gameObject.layer = 12;

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wolfboss")
        {
            Destroy(this.gameObject);
            --collision.gameObject.GetComponent<BossWolf>().HP; 
        }
    }

    IEnumerator Homing()
    {
        Vector2 Direction = (Vector2)Target.transform.position - RigidBody.position;

        Direction.Normalize();

        float RotateAmount = Vector3.Cross(Direction, transform.up).z;

        RigidBody.angularVelocity = -RotateAmount * RotateSpeed;

        RigidBody.velocity = transform.up * MissileSpeed;

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Homing());
    }
}
