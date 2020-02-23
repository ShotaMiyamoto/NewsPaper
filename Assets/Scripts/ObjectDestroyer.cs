using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private GameObject Player;
    private bool isGameOverRecv = false;

    private void Start()
    {
        isGameOverRecv = GameManager.Instance.IsGameOver;
        if (!isGameOverRecv)
        {
            Player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGameOverRecv = GameManager.Instance.IsGameOver;
        if (!isGameOverRecv)
        {
            if (Player.transform.position.z > this.transform.position.z + 100f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
