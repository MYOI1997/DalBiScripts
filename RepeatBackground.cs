using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 드래곤 보스 맵 반복에 사용 됨 */

public class RepeatBackground : MonoBehaviour {

    private BoxCollider2D BackgoundCollider;
    private float BackgroundSize;


	// Use this for initialization
	void Start ()
    {
        BackgoundCollider = GetComponent<BoxCollider2D>();
        BackgroundSize = BackgoundCollider.size.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.y + 1 < -BackgroundSize)
        {
            RepeateBackground();
        }
	}

    void RepeateBackground()
    {
        Vector2 BGoffset = new Vector2(0, BackgroundSize * 2f * transform.localScale.y);
        transform.position = (Vector2)transform.position + BGoffset;
    }
}
