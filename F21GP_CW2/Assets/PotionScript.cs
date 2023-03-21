using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroyed when player collides with it...
        if (collision.gameObject.name.Contains("Player"))
            Destroy(gameObject);
    }
}
