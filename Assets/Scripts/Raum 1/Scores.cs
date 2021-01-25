using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    public static float scoreValue = Mathf.Clamp(0, 0, Mathf.Infinity);
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "X" + scoreValue;

        if (scoreValue > 10)
        {
            SceneManager.LoadScene("Uebergang-nach-Kampf");
        }
    }
}
