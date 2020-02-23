using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Cinemachine;

public class PlayerController : MonoBehaviour
{
    //===================移動処理関係=====================

    /// <summary>
    /// 自分のRigidbody
    /// </summary>
    private Rigidbody rbodySelf;

    /// <summary>
    /// 後輪のRigidbody
    /// </summary>
    public Rigidbody rbWheel;

    /// <summary>
    /// 後輪の最高回転速度
    /// </summary>
    [SerializeField] private float maxAngularVel = 500f;

    /// <summary>
    /// Trueで移動可能
    /// </summary>
    [SerializeField] private bool canMove = true;

    /// <summary>
    /// Z方向の速度上限
    /// </summary>
    [SerializeField] private float maxSpeed = 30f;

    /// <summary>
    /// Z軸の加速度
    /// </summary>
    [SerializeField] private float accel = 250f;


    //===================回転処理関係=====================

    /// <summary>
    /// 回転する時の速度
    /// </summary>
    [SerializeField] private float sideMoveSpeed = 50f;

    /// <summary>
    /// InputGetAxisで得た方向と回転速度を掛け合わせる受け皿
    /// </summary>
    private float x = 0;

    //===================射撃処理関係=====================
    public GameObject newsPaperPrefab;

    //===================ゲームオーバー処理関係=====================
    public GameObject explosionPrefab;
    public GameObject firePrefab;

    //===================得点処理関係=====================
    private int points = 0;
    public TextMeshProUGUI pointText;

    //===================サウンド処理関係=====================
    public SoundManager soundManager;
    private AudioSource[] audioSource; //0がバイク音ループ　1が投げる音
    


    // Start is called before the first frame update
    void Start()
    {
        rbodySelf = GetComponent<Rigidbody>();
        rbWheel.maxAngularVelocity = maxAngularVel;
        pointText.text = "得点:" + points;
        audioSource = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースバーで射撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(newsPaperPrefab, this.transform.position + new Vector3(0,1.5f,0f), newsPaperPrefab.transform.rotation);
            audioSource[1].Play(); //投げる音再生
        }

        x = Input.GetAxis("Horizontal") * sideMoveSpeed;

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            //最高速度に達してなければトルクをかける
            if (rbodySelf.velocity.magnitude < maxSpeed)
            {
                //rb.AddForce(new Vector3(0, 0, accel));
                rbWheel.AddTorque(transform.right * accel);
            }

            //横矢印の入力があれば回転。なければ徐々に減速する
            if (Input.GetAxis("Horizontal") != 0)
            {
                rbodySelf.AddTorque(new Vector3(x, 0, 0));
            }
            else
            {
                rbodySelf.angularVelocity = Vector3.zero;
                //Debug.Log("回転制御中");
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //地面にタイヤ以外の場所がヒットしたら爆発
        if(col.tag == "Ground")
        {
            GameManager.Instance.GameOver();
            Instantiate(explosionPrefab, this.transform.position, explosionPrefab.transform.rotation);
            Instantiate(firePrefab, this.transform.position - new Vector3 (0, this.transform.position.y, 0) , firePrefab.transform.rotation);
            soundManager.PlaySound(0);
            //カメラシェイク用
            //var source = GetComponent<Cinemachine.CinemachineImpulseSource>();
            //source.GenerateImpulse();
            Destroy(this.gameObject);
        }
    }

    public void GetPoints(int value)
    {
        points += value;
        pointText.text = "得点:" + points;
    }
}
