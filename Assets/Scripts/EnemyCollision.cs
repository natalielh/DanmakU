using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public AudioSource EnemyHitSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth.health -= 1.0f;
        EnemyHitSound.Play();
        //Destroy(collision.gameObject);
    }
}
