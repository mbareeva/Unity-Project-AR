﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
        void OnTriggerEnter (Collider other) {
        if (other.tag == "Enemy") {
            //if get hit, reduce the health.
            fighterController.instance.react();
        }
    }
}
