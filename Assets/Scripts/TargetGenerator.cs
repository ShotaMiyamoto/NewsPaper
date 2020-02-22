using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public GameObject[] Targets;

    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0, Targets.Length);
        Instantiate(Targets[randomNum], this.transform.position, Targets[randomNum].transform.rotation);
    }

}
