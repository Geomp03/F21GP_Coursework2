using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUp : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.currentHealth++;
            Destroy(gameObject);
        }
    }
}
