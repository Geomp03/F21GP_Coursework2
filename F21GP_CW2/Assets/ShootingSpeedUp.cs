using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpeedUp : MonoBehaviour
{
    public PlayerAim playerAim;

    private void Start()
    {
        playerAim = FindObjectOfType<PlayerAim>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerAim.shootForce = playerAim.shootForce + 5;
            Destroy(gameObject);
        }
    }
}
