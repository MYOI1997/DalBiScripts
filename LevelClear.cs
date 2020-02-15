using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class LevelClear : MonoBehaviour
{

    public void Start()
    {
        PlayerPrefs.SetInt("ReachLevel", 16);
    }

    public void GoNextLevel()
    {
        int CurrentLevel = PlayerPrefs.GetInt("ReachLevel", 1);

        PlayerPrefs.SetInt("ReachLevel", CurrentLevel + 1);

        SceneManager.LoadScene(CurrentLevel + 1);
    }

    public void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}
