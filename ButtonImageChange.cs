using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class ButtonImageChange : MonoBehaviour
{
    AudioSource BGM;

    public int Count = 0;
    public int Num = 0;
    public SpriteRenderer ButtonImage;                  
    public Sprite[] sprites = new Sprite[2];             

    // Use this for initialization 
    void Start()
    {
        BGM = GetComponent<AudioSource>();
        ButtonImage = GetComponent<SpriteRenderer>();
        ButtonImage.sprite = sprites[0];                  
    }

    // Update is called once per frame 
    void Update()
    {
        if(gameObject.GetComponent<Image>().sprite == sprites[0])
        {
            AudioListener.volume = 1;
        }
        else if(gameObject.GetComponent<Image>().sprite == sprites[1])
        {
            AudioListener.volume = 0;
        }
    }

    public void OnClick()
    {
        Count++;                                      
        Num = Count % 2;
        gameObject.GetComponent<Image>().sprite = sprites[Num]; 
        Num = 0;                                       
    }
}