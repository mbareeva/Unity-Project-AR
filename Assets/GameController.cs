using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public static GameController instance;
   public static bool allowMovement = false;

   void Awake()
   {
       if(instance == null) {
           instance = this;
       }
   }
}
