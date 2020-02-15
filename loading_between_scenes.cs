using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class loading_between_scenes : MonoBehaviour
{
    public Slider TargetSlider;

    bool IsDone = false;
    float ProcessTime = 0f;

    AsyncOperation TargetAsyncOperation;

    void Start()
    {
        StartCoroutine(StartLoad("Main"));
    }

    void Update()
    {
        ProcessTime += Time.deltaTime;
        TargetSlider.value = ProcessTime;

        if (ProcessTime >= 3)
        {
            TargetAsyncOperation.allowSceneActivation = true;
        }
    }

    public IEnumerator StartLoad(string strSceneName)
    {
        TargetAsyncOperation = SceneManager.LoadSceneAsync(strSceneName);
        TargetAsyncOperation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (TargetAsyncOperation.progress < 0.1f)
            {
                TargetSlider.value = TargetAsyncOperation.progress;

                yield return false;
            }
        }
    }
}
