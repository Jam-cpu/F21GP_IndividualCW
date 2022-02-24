using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static int Score = 0;

    private void Update() 
    {
        scoreText.text = "Score: " + Score.ToString();    
    }
}
