using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Player player;
    // public PlayerColour playerColour;
    private Material material;
    // private Color bulletColour;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        // playerColour = FindObjectOfType<PlayerColour>();
        material = GetComponent<SpriteRenderer>().sharedMaterial;
        material.SetColor("_Color", player.finalColour);

        // Debug.Log("BulletScript:  player.tempColour - " + player.tempColour + " player.baseColour - " + player.baseColour);
        // Debug.Log("BulletScript:  player.finalColour - " + player.finalColour);
    }

    private void Update()
    {
        material.SetColor("_Color", player.finalColour);
    }
        
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        // Currently it is dirrectly connected to the players colour so this is conflicting...
        //if (collision.gameObject.name.Contains("BluePuddle"))
        //    player.tempColour = "Blue";
        //else if (collision.gameObject.name.Contains("RedPuddle"))
        //    player.tempColour = "Red";
        //else if (collision.gameObject.name.Contains("YellowPuddle"))
        //    player.tempColour = "Yellow";
    }
}
    