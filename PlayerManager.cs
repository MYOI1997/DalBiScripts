using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class PlayerManager : MonoBehaviour
{

    public BoxCollider2D DalbiCollider;
    public BoxCollider2D DalbiFootCollider;

    private Transform PlayerTransform;
    private Rigidbody2D PlayerRigidBody;
    private Animator PlayerAnimator;
    private ButtonManager BM;

    public string CurrentSceneName;
    public int CurrentSceneIndex;

    public float MoveSpeed = 5f;    
    public float JumpPower = 6.5f;  

    public int MaxJumpCount = 1;    
    public int JumpCount;           

    public bool Alive = true;        
    public bool CanMove = true;     
    public bool CanJump = true;     
    public bool CanDash = false;    

    private void Awake()
    {
        CurrentSceneName = SceneManager.GetActiveScene().name;
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        if (CurrentSceneIndex >= 11)
        {
            MaxJumpCount = 2;
        }

        PlayerTransform = GetComponent<Transform>();
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        BM = GetComponent<ButtonManager>();
    }

    private void FixedUpdate()
    {
        if (PlayerRigidBody.velocity.y < -5f)
        {
            PlayerAnimator.SetBool("Fall", true);
        }
        else
        {
            PlayerAnimator.SetBool("Fall", false);
        }

        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            CanJump = true;
            JumpCount = MaxJumpCount;
            PlayerAnimator.SetBool("Jump", false);
            PlayerAnimator.SetBool("DoubleJump", false);
            PlayerAnimator.SetBool("MushJump", false);
            PlayerAnimator.SetBool("Fall", false);
        }
    }

    public void Die()
    {
        Alive = false;
        DalbiCollider.enabled = false;
        DalbiFootCollider.enabled = false;

        PlayerRigidBody.velocity = new Vector2(0, 0);
        Vector2 dieVelocity = new Vector2(0, 5f);
        PlayerRigidBody.AddForce(dieVelocity, ForceMode2D.Impulse);

        PlayerAnimator.SetBool("Die", true);
        StartCoroutine(Restart());

    }

    public void Movement()
    {
        if (CanMove && Alive)
        {
            if (BM.InputLeft)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                PlayerTransform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            }
            if (BM.InputRight)
            {
                transform.localScale = new Vector3(1, 1, 1);
                PlayerTransform.position += Vector3.right * MoveSpeed * Time.deltaTime;
            }
        }
    }

    public void Jump()
    {
        Vector2 jumpVelocity = new Vector2(0, JumpPower);

        if (Alive && CanJump && BM.InputJump)
        {
            if (JumpCount > 1)
            {
                PlayerRigidBody.velocity = new Vector2(0, 0);
                PlayerRigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
                PlayerAnimator.SetBool("DoubleJump", true);
                PlayerAnimator.SetBool("Jump", false);
                PlayerAnimator.SetBool("Fall", false);
                PlayerAnimator.SetBool("MushJump", false);

                JumpCount--;
            }
            else if (JumpCount > 0)
            {
                PlayerRigidBody.velocity = new Vector2(0, 0);
                PlayerRigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
                PlayerAnimator.SetBool("Jump", true);
                PlayerAnimator.SetBool("DoubleJump", false);
                PlayerAnimator.SetBool("Fall", false);
                PlayerAnimator.SetBool("MushJump", false);

                JumpCount--;
            }

            if (JumpCount == 0)
            {
                BM.InputJump = false;
                CanJump = false;
            }
        }
    }

    //대쉬함수
    public void Dash()
    {
        if (BM.InputDash && Alive && CanDash)
        {
            BM.InputDash = false;

            if (transform.localScale == new Vector3(-1, 1, 1))
            {
                Vector2 DashVelocity = new Vector2(-5f, 0);
                PlayerRigidBody.velocity = new Vector2(0, 0);
                PlayerRigidBody.AddForce(DashVelocity, ForceMode2D.Impulse);
                StartCoroutine(DashDelay());
            }

            if (transform.localScale == new Vector3(1, 1, 1))
            {
                Vector2 DashVelocity = new Vector2(5f, 0);
                PlayerRigidBody.velocity = new Vector2(0, 0);
                PlayerRigidBody.AddForce(DashVelocity, ForceMode2D.Impulse);
                StartCoroutine(DashDelay());
            }
        }
    }

    IEnumerator DashDelay()
    {
        CanDash = false;

        yield return new WaitForSeconds(4f);

        CanDash = true;
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(CurrentSceneName);
    }
}
