using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1920, 1080, true);
    }

    void Update () {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Stage");
            }
        }
    }

}
