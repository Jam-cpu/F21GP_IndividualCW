using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private int damage;


    public int GetDamage()
    {
        return damage;
    }
}
