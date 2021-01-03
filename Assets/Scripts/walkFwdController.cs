using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Controller for right (forward) button.
public class walkFwdController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // If the button is pressed, then it will change the boolean in the Animator's parameters.
    public void OnPointerDown (PointerEventData data) {
        fighterController.mvFwd = true;
    }

    public void OnPointerUp (PointerEventData data) {
        fighterController.mvFwd = false;
    }
}
