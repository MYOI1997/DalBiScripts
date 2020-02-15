using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class StagePause : MonoBehaviour
{

    public GameObject PauseUI;
    public GameObject Settings;
    public GameObject DeadOption;

    private bool paused = false;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)

        {
            if (Input.GetKey(KeyCode.Escape))
            {
                paused = !paused;
            }
        }

        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        paused = !paused;
    }

    public void Restart()
    {
        string Scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(Scene);
    }

    public void StageSelect()
    {
        SceneManager.LoadScene("Stage");
    }

    public void HomeSelect()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void Apply()
    {
        Settings.SetActive(false);
    }

    public void PauseBtn()
    {
        paused = !paused;

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            //Settings.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
