using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class Video : MonoBehaviour {

    bool IsDone = false;
    float fTime = 0f;
    AsyncOperation AsyncOperationProcess;

	void Start ()
    {
        StartCoroutine(StartLoad("Main"));
    }
	
	void Update ()
    {
        fTime += Time.deltaTime;

        if (fTime >= 5)
        {
            AsyncOperationProcess.allowSceneActivation = true;
        }

    }
    public IEnumerator StartLoad(string strSceneName)
    {
        AsyncOperationProcess = SceneManager.LoadSceneAsync(strSceneName);
        AsyncOperationProcess.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (AsyncOperationProcess.progress < 0.9f)
            {
                yield return true;
            }
        }
    }
}
