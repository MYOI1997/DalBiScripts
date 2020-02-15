using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class Prologue : MonoBehaviour {

    bool IsDone = false;
    float ProcessTime = 0f;

    AsyncOperation ProcessAsyncOperation;

    int InitialPlay; // 최초 재생 여부
    public VideoPlayer TargetVideoPlayer;

    // Use this for initialization
    void Start()
    {
        InitialPlay = PlayerPrefs.GetInt("InitialPlay", 0);

        if (InitialPlay == 1)
        {
            ProcessTime = 70;
        }

        StartCoroutine(StartLoad("Stage"));
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTime += Time.deltaTime;

        if (ProcessTime >= 70)
        {
            ProcessAsyncOperation.allowSceneActivation = true;
        }

    }
    public IEnumerator StartLoad(string strSceneName)
    {
        ProcessAsyncOperation = SceneManager.LoadSceneAsync(strSceneName);
        ProcessAsyncOperation.allowSceneActivation = false;

        PlayerPrefs.SetInt("InitialPlay", 1);

        if (IsDone == false)
        {
            IsDone = true;

            while (ProcessAsyncOperation.progress < 0.9f)
            {
                yield return true;
            }
        }
    }
}
