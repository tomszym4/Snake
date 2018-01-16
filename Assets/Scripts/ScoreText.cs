using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Used on Score text object in Game and GameOver scenes. </summary>
public class ScoreText : MonoBehaviour {

    private Text score;

    private void Start()
    {
        score = GetComponent<Text>();
    }

    private void Update()
    {
        score.text = "Score " + GameManager.Score;
    }
}
