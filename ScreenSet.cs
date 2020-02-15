using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 드래곤 보스 맵에서 화면 돌려주기 용으로 사용됨 */

public class ScreenSet : MonoBehaviour {

    void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Start ()
    {
        Physics2D.gravity = new Vector2(0, -15F);
    }
}
