using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.05 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */
/* 맵 선택 창 화면 스크롤에 사용했었으나, Scroll Rect 객체의 지원으로 사용하지 않으므로 최종 수정 후 삭제 */

public class Scroll : MonoBehaviour {

    public const float scrollSpeed = 0.1f;

    private Material TargetMaterial;

    Vector2 NewOffset;

    void Start()
    {
        TargetMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        NewOffset = TargetMaterial.mainTextureOffset;
        NewOffset.Set(0, NewOffset.y + (scrollSpeed * Time.deltaTime));
        TargetMaterial.mainTextureOffset = NewOffset;
    } 

}
