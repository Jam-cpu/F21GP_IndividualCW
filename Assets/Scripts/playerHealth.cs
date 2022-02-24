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
        healthText.text = $"HP: {playerHP}";
    }

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
