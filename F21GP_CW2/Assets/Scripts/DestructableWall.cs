using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWall : MonoBehaviour
{
    Dictionary<Color, string> ColourDict = new Dictionary<Color, string>()
    {
        {new Color(0.1921569f, 0.3647059f, 0.9019608f), "Blue"},
        {new Color(0.9372550f, 0.2470588f, 0.2509804f), "Red"},
        {new Color(0.9607844f, 0.8705883f, 0.1960784f), "Yellow"},
        {new Color(0.9058824f, 0.5725490f, 0.1568628f), "Orange"},
        {new Color(0.2156863f, 0.9490197f, 0.0000000f), "Green"},
        {new Color(0.6823530f, 0.0784314f, 0.9686275f), "Purple"},
        {Color.black, "Default"}
    };

    private void OnTriggerEnter2D (Collider2D collider)
    {
        // Destroyed when player bullet collides of the correct collor collides with it.
        if (collider.gameObject.tag == "Bullet")
        {
            Debug.Log("Wall collided with bullet");
            string bulletColour = ColourDict[collider.gameObject.GetComponent<SpriteRenderer>().sharedMaterial.color];
            if (gameObject.name.Contains(bulletColour))
            {
                Destroy(gameObject);
                // Maybe add explosion or discovery sound effect?
            }
        }
    }
}
