using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject[] fireWorksPrefab;
    private int points = 10;
    private GameObject player;
    [SerializeField] private int levelNum = 0;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Newspaper"){
            if(levelNum != 3)
            {
                int i = fireWorksPrefab.Length;
                Instantiate(fireWorksPrefab[i], this.gameObject.transform.position, fireWorksPrefab[i].transform.rotation);
            }
            else
            {
                Instantiate(fireWorksPrefab[0], this.gameObject.transform.position, fireWorksPrefab[0].transform.rotation);
                Instantiate(fireWorksPrefab[1], this.gameObject.transform.position, fireWorksPrefab[1].transform.rotation);
                Instantiate(fireWorksPrefab[2], this.gameObject.transform.position, fireWorksPrefab[2].transform.rotation);
            }
            
            player.GetComponent<PlayerController>().GetPoints(points);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        switch (levelNum) //レベルによってポイントを変える
        {
            case 0:
                points = 10;
                break;
            case 1:
                points = 20;
                break;
            case 2:
                points = 30;
                break;
            case 3:
                points = 40;
                break;
            default:
                //何もしない
                break;
        }
    }
    
}
