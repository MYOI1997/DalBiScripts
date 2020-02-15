using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class Dragon : MonoBehaviour
{
    public GameObject FireAnimation;
    public Animator DragonAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerManager>().Die();
        }
    }

    private void Start()
    {
        InvokeRepeating("Fire", 10f, 10f);
    }

    void Fire()
    {
        FireAnimation.SetActive(true);
        DragonAnimator.Play("Fire");

        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Fire") &&
            DragonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            FireAnimation.SetActive(false);
        }
    }

}
