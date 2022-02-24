using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameWin : MonoBehaviour
{
    public GameObject[] enemy;

    void Update() 
    {
        // adds objects with Enemy tag to array, when it is NULL you have killed
        // all enemies and thus reached a win condition and resets the game
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemy.Length == 0)
        {
            SceneManager.LoadScene("courseworkscene");
            Scoreboard.Score = 0;                       // ensures the score is also reset
        }    
    }
}
