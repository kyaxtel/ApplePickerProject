using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("Score", 0);

        scoreText.text = "Score: " + lastScore;
    }
}
