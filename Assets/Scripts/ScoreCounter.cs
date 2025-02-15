using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private TextMeshProUGUI uiText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString( "#,0" ); // This 0 is a zero!
        PlayerPrefs.SetInt("Score", score);
    }
}
