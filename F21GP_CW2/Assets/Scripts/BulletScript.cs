using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Player player;
    private Material material;

    private DestructableWall colors;

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

            Debug.Log("Bullet collided with enemy");
                
            if (this.material.color == collision.gameObject.GetComponent<SpriteRenderer>().material.color)
            {
                Destroy(collision.gameObject);
                Destroy(this, 0.1f);
            }
            //else
            //{
            //    Destroy(this, 0.1f);
            //}
          
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
    