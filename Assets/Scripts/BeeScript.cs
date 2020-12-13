using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{

    // Update is called once per frame (60 times pro sec)
    void Update()
    {
        //make bees fly - moves the objects in the upper direction
        transform.Translate(Vector3.up * Time.deltaTime * 0.2f);
        
    }
}
