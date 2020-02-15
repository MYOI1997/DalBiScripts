using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 사용하지 않는 스크립트이므로 최종 수정후 삭제하기 */

public class ImageAnimation : MonoBehaviour
{

    public Sprite[] Sprites;
    public int SpritePerFrame = 6;
    public bool Loop = true;
    public bool DestroyOnEnd = false;

    private int Index = 0;
    private int Frame = 0;
    private Image TargetImage;

    void Awake()
    {
        TargetImage = GetComponent<Image>();
    }

    void Update()
    {
        if (!Loop && Index == Sprites.Length)
        {
            return;
        }

        Frame++;

        if (Frame < SpritePerFrame)
        {
            return;
        }

        TargetImage.sprite = Sprites[Index];
        Frame = 0;
        Index++;

        if (Index >= Sprites.Length)
        {
            if (Loop) { Index = 0; }
            if (DestroyOnEnd) { Destroy(gameObject); }
        }
    }
}