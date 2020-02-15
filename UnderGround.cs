using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 캐릭터의 위치에 따라 언덕 충돌체 On / Off */

public class UnderGround : MonoBehaviour {

    private BoxCollider2D BoxCollider;
    private GameObject Target;

    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Target = GameObject.Find("Dalbi");
    }

    void Update ()
    {
        if(Target.transform.position.y < BoxCollider.transform.position.y)
        {
            BoxCollider.enabled = false;
        }
        else
        {
            BoxCollider.enabled = true;
        }
	}
}
