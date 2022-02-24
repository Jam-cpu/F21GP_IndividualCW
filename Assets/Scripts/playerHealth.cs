using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    private int playerHP = 100;
    [SerializeField] private TextMeshProUGUI healthText;

    void Update()
    {
        // displays current hp by calling the int directly
        healthText.text = $"HP: {playerHP}";
    }

    // this method detects damage from collisions with enemies
    // it also hits a loose condition when health reaches 0
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            playerHP -=10;
            if(playerHP == 0)
            {
                SceneManager.LoadScene("courseworkscene");
                Scoreboard.Score = 0;
            }
        }
    }
}
