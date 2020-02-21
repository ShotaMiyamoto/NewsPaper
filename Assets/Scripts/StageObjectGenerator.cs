using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjectGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject[] roadPrefabs;
    private float currentCourseEndPos = 10f; //最後に生成したコースプレファブの終点（次のコースをくっつけるZ座標）

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z + 100f > currentCourseEndPos)
        {
            Instantiate(roadPrefabs[0], new Vector3(0, 0, currentCourseEndPos), roadPrefabs[0].transform.rotation); //生成
            currentCourseEndPos += 10f;
        }
    }
}
