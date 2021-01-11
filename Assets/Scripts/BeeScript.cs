using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public Transform arCamera;

    // Update is called once per frame (60 times pro sec)
    void Update()
    {
        arCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
      
        //make bees fly - moves the objects towards the camera
        transform.LookAt(arCamera, Vector3.up);
        transform.Rotate(0, -100, 0);
        transform.position = Vector3.Lerp(transform.position, arCamera.position, 0.01f);

        //collision
        float dist = Vector3.Distance(transform.position, arCamera.transform.position);
        if (dist < 1)
        {
            Scores.scoreValue -= 1;
            Destroy(gameObject);
        }
        
    }

}