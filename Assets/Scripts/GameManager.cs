using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>
    /// ゲームオーバー（操作などができない状態か否か）
    /// </summary>
    private bool isGameOver = false;

    public bool IsGameOver //外から読み取る用
    {
        get
        {
            return isGameOver;
        }
    }

    /// <summary>
    /// リスタートできる状態か
    /// </summary>
    private bool canRestart = false;

    /// <summary>
    /// ゲームオーバー時に表示するパネルやテキスト郡
    /// </summary>
    public GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f; //タイムスケールリセット
    }

    // Update is called once per frame
    void Update()
    {
        if (canRestart && Input.GetKeyDown(KeyCode.Space))
        {
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }
    }

    public void GameOver()　//ゲームオーバーしたら4秒後にパネルの有効化とタイムスケールを停止。
    {
        isGameOver = true; //すぐにゲームオーバーにする

        StartCoroutine(DelayMethod(4.0f, () =>
        { 
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            canRestart = true;
        }));
        
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
