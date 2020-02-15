using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 다음 씬의 이름을 직접입력하는 방식에서 자동으로 다음 씬 정보를 가져오도록 수정 */

public class Portal : MonoBehaviour
{
    private int NextSceneIndex;

    void Start()
    {
        NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            int CurrentLevel = PlayerPrefs.GetInt("ReachLevel", 1);

            PlayerPrefs.SetInt("ReachLevel", CurrentLevel + 1);

            SceneManager.LoadScene(CurrentLevel + 1);
            StartCoroutine(Teleport());
        }

    }

    IEnumerator Teleport()
    {
        SceneManager.LoadSceneAsync(NextSceneIndex);

        yield return null;
    }


}