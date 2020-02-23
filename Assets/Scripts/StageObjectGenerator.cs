using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjectGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject[] roadPrefabs;
    private float currentCourseEndPos = 10f; //最後に生成したコースプレファブの終点（次のコースをくっつけるZ座標）
    private bool isGameOverRecv = false;

    // Start is called before the first frame update
    void Start()
    {
        isGameOverRecv = GameManager.Instance.IsGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        isGameOverRecv = GameManager.Instance.IsGameOver;
        if (!isGameOverRecv)
        {
            if (player.transform.position.z + 100f > currentCourseEndPos)
            {
                int i = Random.Range(0, 6);
                Instantiate(roadPrefabs[i], new Vector3(0, 0, currentCourseEndPos), roadPrefabs[i].transform.rotation); //生成
                currentCourseEndPos += 10f;
            }
        }
    }
}
