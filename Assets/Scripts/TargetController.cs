using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject fireWorksPrefab;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Newspaper"){
            Instantiate(fireWorksPrefab, this.gameObject.transform.position, fireWorksPrefab.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    
}
