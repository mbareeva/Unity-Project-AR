using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour {
    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            //if get hit, reduce the health.
            enemyController.instance.enemyReact();
        }
    }
}