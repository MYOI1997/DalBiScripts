using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class ItemSpawn : MonoBehaviour {

    public GameObject TargetItem;

    void Update()
    {
        float RandomX = Random.Range(-26f, 22f);

        if (TargetItem == null)
        {
            TargetItem = Instantiate(Resources.Load("Prefabs/Missile"), new Vector3(0, -26f, 0), Quaternion.identity) as GameObject;
            TargetItem.transform.parent = null;
            TargetItem.transform.localPosition = Vector3.zero;
            TargetItem.transform.position = new Vector3(RandomX, -26f, 0f);
        }
    }
}
