using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameWin : MonoBehaviour
{
    public GameObject[] enemy;

    void Update() 
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemy.Length == 0)
        {
            SceneManager.LoadScene("courseworkscene");
            Scoreboard.Score = 0;
        }    
    }
}
