using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 2020.02.04 수정 */
/* 스크립트 명 변경 */
/* 변수 명, 함수 명 수정 */

public class SpawnRock : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("Spawn");
	}

    IEnumerator Spawn()
    {
        while (true)
        {
            int RandomRock = Random.Range(1, 5);
            float RandomX = Random.Range(-49f, -40f);
            GameObject newArrow = Instantiate(Resources.Load("Prefabs/Rock"+RandomRock), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newArrow.transform.parent = null;
            newArrow.transform.localPosition = Vector3.zero;
            newArrow.transform.position = new Vector3(RandomX, 50, 0f);

            yield return new WaitForSeconds(3.5f);
        }
    }
}
