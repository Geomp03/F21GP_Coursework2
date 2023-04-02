using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy bullet on contact with player and walls
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.name.Contains("Pink"))
                Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
