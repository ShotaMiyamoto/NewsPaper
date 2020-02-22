using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public GameObject[] Targets;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Targets[0], this.transform.position, Targets[0].transform.rotation);
    }

}
