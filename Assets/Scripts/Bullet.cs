using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// removes bullets after 2 seconds after spawning
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
