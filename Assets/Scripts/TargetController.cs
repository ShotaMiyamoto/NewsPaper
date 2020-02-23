using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private GameObject[] fireWorksPrefab;
    private int points = 10;
    private GameObject player;
    [SerializeField] private int levelNum = 0;
    [SerializeField] private SoundManager soundManager;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Newspaper"){

            switch (levelNum)
            {
                case 0:
                case 1:
                case 2:
                    Instantiate(fireWorksPrefab[0], this.gameObject.transform.position, fireWorksPrefab[0].transform.rotation);
                    soundManager.PlaySound(1);
                    soundManager.PlaySound(2);
                    break;
                case 3:
                    Instantiate(fireWorksPrefab[0], this.gameObject.transform.position, fireWorksPrefab[0].transform.rotation);
                    soundManager.PlaySound(1);
                    soundManager.PlaySound(2);
                    break;
                default:
                    //何もしない
                    break;
            }
            player.GetComponent<PlayerController>().GetPoints(points);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();

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
