using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 사용하지 않으므로 최종 수정 후 삭제 */

public class StageChangeButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Stage1()
    {
        SceneManager.LoadScene("1-1");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("1-2");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("1-3");
    }

    public void Stage4()
    {
        SceneManager.LoadScene("1-4");
    }

    public void Stage5()
    {
        SceneManager.LoadScene("1_5");
    }
}