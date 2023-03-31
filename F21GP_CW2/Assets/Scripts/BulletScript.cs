using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Player player;
    private Material material;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        material = GetComponent<SpriteRenderer>().material;
        material.SetColor("_Color", player.finalColour);

        // Debug.Log("BulletScript:  player.tempColour - " + player.tempColour + " player.baseColour - " + player.baseColour);
        // Debug.Log("BulletScript:  player.finalColour - " + player.finalColour);
    }
        
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
    