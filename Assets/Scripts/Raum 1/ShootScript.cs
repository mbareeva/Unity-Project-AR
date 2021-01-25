using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    public AudioSource source;
    public AudioClip puff;

    public void Shoot() { 

        RaycastHit hit;

        //projected from the center of the phone in the real world (Raycast); "out hit" is the result
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)) {

            //if it hits bee1, then destroy bee1 and so on..
            if (hit.transform.name == "Bee(Clone)")
            {
                source.Play();
                Scores.scoreValue += 1;
                Destroy(hit.transform.gameObject);
            }
        }
    }

}
