using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private PlayerColour playerColour;
    private Material material;
    private Color bulletColour;

    private void Awake()
    {
        playerColour = FindObjectOfType<PlayerColour>();
        material = GetComponent<SpriteRenderer>().sharedMaterial;
        material.SetColor("_Color", bulletColour);
    }

    private void Update()
    {
        material.SetColor("_Color", playerColour.finalColour);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("BluePuddle"))
            playerColour.tempColour = "Blue";
        else if (collision.gameObject.name.Contains("RedPuddle"))
            playerColour.tempColour = "Red";
        else if (collision.gameObject.name.Contains("YellowPuddle"))
            playerColour.tempColour = "Yellow";
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
    