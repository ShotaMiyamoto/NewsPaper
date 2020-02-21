using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //===================移動処理関係=====================
    private Rigidbody rb;
    [SerializeField]
    private float maxSpeed = 30f;
    [SerializeField]
    private float accel = 250f;

    //===================射撃処理関係=====================
    public GameObject newsPaperPrefab;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(newsPaperPrefab, this.transform.position + new Vector3(0,1f,0f), newsPaperPrefab.transform.rotation);
        }

    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(new Vector3(0,0,accel));
        }
    }
}
