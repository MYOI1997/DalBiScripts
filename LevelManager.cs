using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class LevelManager : MonoBehaviour
{
    Button[] LevelButtons;

    private void Awake()
    {
        int ReachLevel = PlayerPrefs.GetInt("ReachLevel", 1);

        LevelButtons = new Button[transform.childCount];

        for(int i = 0;  i < LevelButtons.Length; i++)
        {
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>();

            if(i + 1 > ReachLevel)
            {
                LevelButtons[i].interactable = false;
            }
        }
    }

    public void PlayLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }
}
