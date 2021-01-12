using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Controller for left button.
public class walkBackController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown (PointerEventData data) {
        fighterController.mvBack = true;
    }

    public void OnPointerUp (PointerEventData data) {
        fighterController.mvBack = false;
    }
}
