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

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "X" + scoreValue;

        if (scoreValue > 15)
        {
            SceneManager.LoadScene("Uebergang-nach-Kampf");
        }
    }
}
