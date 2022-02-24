using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifetime = 2f;

    private void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    private void onCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
