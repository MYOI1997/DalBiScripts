using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class ButtonManager : MonoBehaviour {

    private Animator ButtonAnimator;
    private PlayerManager PM; 

    public bool InputLeft = false, InputRight = false, InputJump = false, InputDash;

    private void Start()
    {
        ButtonAnimator = GetComponent<Animator>();
        PM = GetComponent<PlayerManager>();
    }

    public void LeftBtnDown()
    {
        InputLeft = true;
        ButtonAnimator.SetBool("Run", true);
    }

    public void LeftBtnUp()
    {
        InputLeft = false;
        ButtonAnimator.SetBool("Run", false);
    }

    public void RightBtnDown()
    {
        InputRight = true;
        ButtonAnimator.SetBool("Run", true);
    }

    public void RightBtnUp()
    {
        InputRight = false;
        ButtonAnimator.SetBool("Run", false);
    }

    public void DashBtnDown()
    {
        InputDash = true;
        PM.Dash();
    }

    public void JumpBtnDown()
    {
        InputJump = true;
        PM.Jump();
    }
}
