using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class SceneChangeButton : MonoBehaviour {

	void Start ()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.SetResolution(1920, 1080, true);
    }

    void Update ()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
    public void prologue()
    {
        SceneManager.LoadScene("prologue");
    }

    public void StageSelcect()
    {
        SceneManager.LoadScene("Stage");
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void Stage4()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void Stage5()
    {
        SceneManager.LoadScene("Stage5");
    }
}
