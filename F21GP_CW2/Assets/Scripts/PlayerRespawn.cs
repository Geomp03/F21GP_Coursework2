using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Player player;
    private Transform respawnPoint;
    [SerializeField] private AudioClip respawn, checkpoint;
    private SoundEffectSource audioSource;

    private void Awake()
    {
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            respawnPoint = collision.transform;
            audioSource.PlaySoundEffect(checkpoint);
        }
    }
    
    // Return player to the last spawn point
    public void Respawn()
    {
        player.transform.position = respawnPoint.position; // Return player to the last checkpoint
        Physics2D.SyncTransforms();
        audioSource.PlaySoundEffect(respawn);              // Play respawn sound effect
        player.currentHealth = player.maxHealth;           // Reset health points
        player.baseColour = "Default";                     // Reset base colour
    }
}
