using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //singleton pattern dafür benutzen, suchen.
   public static GameController instance;
   public static bool allowMovement = false;
   private  bool played = false;
   public AudioClip[] audioClip;
   AudioSource audioc;

   void Awake()
   {
       if(instance == null) {
           instance = this;
       }
   }
   void Start() {
       audioc = GetComponent<AudioSource>();
   }

   private void playAudioTrack(int clip) {
       audioc.clip = audioClip[clip];
       audioc.Play();
   }

   void Update() {
       if(played == false) {
           played = true;
           StartCoroutine(round1());
       }
   }

   IEnumerator round1() {
       yield return new WaitForSeconds(0);
       playAudioTrack(0);
       StartCoroutine(prepareYourself());

   }

   IEnumerator prepareYourself() {
       yield return new WaitForSeconds(1.2f);
       playAudioTrack(1);
       StartCoroutine(start321());
   }

   IEnumerator start321() {
       yield return new WaitForSeconds(2f);
       playAudioTrack(2);
       StartCoroutine(allowplayerMovement());
   }

   IEnumerator allowplayerMovement() {
       yield return new WaitForSeconds(5f);
       allowMovement = true;
       Debug.Log(allowMovement);
   }
}
