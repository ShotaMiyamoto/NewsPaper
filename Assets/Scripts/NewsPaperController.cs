using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperController : MonoBehaviour
{
    //===================移動処理関係=====================
    private Rigidbody rb;
    [SerializeField]
    private float movePower = 30f;

    //===================自動破棄処理関係=====================
    [SerializeField]
    private float lifeTime = 3f;
    float timeElapsed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-movePower, 0, 0), ForceMode.Impulse);
    }

    
    void Update()
    {
        //ライフ時間に達したら自動的に削除する
        timeElapsed += Time.deltaTime;
        if(timeElapsed > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

}
