using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject splashes;

    //when the user clicks Shoot button, this function is called
    public void Shoot() { 

        RaycastHit hit;

        //projected from the center of the phone in the real world (Raycast); "out hit" is the result
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)) {

            //if it hits bee1, then destroy bee1 and so on..
            if (hit.transform.name == "Bee(Clone)" || hit.transform.name == "bee1(Clone)" || hit.transform.name == "bee3(Clone)")
            {

                Destroy(hit.transform.gameObject);

                //when the bee is destroyed, show me splashes
                Instantiate(splashes, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

}
