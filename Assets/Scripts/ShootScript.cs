using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;

    //public GameObject blood;
    //public ParticleSystem ps;

    // When the enemy dies, we play an explosion
    public Transform explosion;

    //when the user clicks Shoot button, this function is called
    public void Shoot() { 

        RaycastHit hit;

        //projected from the center of the phone in the real world (Raycast); "out hit" is the result
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)) {

            //if it hits bee1, then destroy bee1 and so on..
            if (hit.transform.name == "Bee(Clone)")
            {
                
                
                Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));
                Scores.scoreValue += 1;
                Destroy(hit.transform.gameObject);
                //when the bee is destroyed, show me splashes
                //Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));

            }
        }
    }

}
