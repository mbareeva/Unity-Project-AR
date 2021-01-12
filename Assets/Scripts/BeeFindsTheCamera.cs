using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeFindsTheCamera : MonoBehaviour
{ 
     void Awake()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
}
