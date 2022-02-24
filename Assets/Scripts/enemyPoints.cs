using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPoints : MonoBehaviour
{
    [SerializeField] public int enemyHealth = 10;

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.transform.name == "defaultBullet(Clone)")
        {
            Scoreboard.Score += 1;
            Debug.Log("Enemy Hit!");
            enemyHealth --;
            if(enemyHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
