using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Uebergang : MonoBehaviour
{
//Link: https://www.youtube.com/watch?v=1qbjmb_1hV4
//Typewriter effect tutorial.
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showText());
    }
    IEnumerator showText() {
        for(int i = 0; i < fullText.Length; i++) {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text =  currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
