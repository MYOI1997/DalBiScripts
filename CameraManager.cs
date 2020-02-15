using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class CameraManager : MonoBehaviour {

    GameObject Player;
    PlayerManager PlayerManager;

    /* 카메라가 이동할 위치 */
    Transform NextPosition; 

    public BoxCollider2D Boundary;
    private Vector3 MinBoundary;
    private Vector3 MaxBoundary;

    private float HalfWidth;
    private float HalfHeight;

    private Camera TargetCamera;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find("Dalbi");
        PlayerManager = GameObject.Find("Dalbi").GetComponent<PlayerManager>();
        NextPosition = Player.transform;

        TargetCamera = GetComponent<Camera>();

        MinBoundary = Boundary.bounds.min;
        MaxBoundary = Boundary.bounds.max;
        HalfHeight = TargetCamera.orthographicSize;
        HalfWidth = HalfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player)
        {
            if (PlayerManager.Alive)
            {
                transform.position = Vector3.Lerp(transform.position, NextPosition.position, 3f * Time.deltaTime);
                transform.Translate(0, 0, -10);
            }
        }

        float ClampedX = Mathf.Clamp(transform.position.x, MinBoundary.x + HalfWidth, MaxBoundary.x - HalfWidth);
        float ClampedY = Mathf.Clamp(transform.position.y, MinBoundary.y + HalfHeight, MaxBoundary.y - HalfHeight);

        transform.position = new Vector3(ClampedX, ClampedY, -10);
    }
}
