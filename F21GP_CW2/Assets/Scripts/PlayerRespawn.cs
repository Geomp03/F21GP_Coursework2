using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Player player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
            respawnPoint = collision.transform;
    }
    
    // Return player to the last spawn point
    public void Respawn()
    {
        player.transform.position = respawnPoint.position; // Return player to the last checkpoint
        player.currentHealth = player.maxHealth;           // Reset health points
        player.baseColour = "Default";                     // Reset base colour
    }
}
