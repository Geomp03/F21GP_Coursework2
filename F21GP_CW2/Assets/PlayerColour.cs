using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColour : MonoBehaviour
{
    public Player player;
    private Material material;

    // [HideInInspector] public string tempColour, baseColour; // moved to player script...
    // [HideInInspector] public Color player.finalColour;

    // Costum Colours Used
    private Color CostumBlue = new Color(0.1921569f, 0.3647059f, 0.9019608f);
    private Color CostumRed = new Color(0.9372550f, 0.2470588f, 0.2509804f);
    private Color CostumYellow = new Color(0.9607844f, 0.8705883f, 0.1960784f);
    private Color CostumOrange = new Color(0.9058824f, 0.5725490f, 0.1568628f);
    private Color CostumGreen = new Color(0.2156863f, 0.9490197f, 0.0000000f);
    private Color CostumPurple = new Color(0.6823530f, 0.0784314f, 0.9686275f);

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().sharedMaterial;
    }
    private void Update()
    {
        ColourEval();
        // Debug.Log("PlayerColour: baseColour - " + player.baseColour + " tempColour - " + player.tempColour);
        ChangeColour(player.finalColour);
    }

    public void ChangeColour(Color color)
    {
        material.SetColor("_Color", color);
    }

    // Evaluate Colour changes and combinations
    public void ColourEval()
    {
        switch (player.baseColour)
        {
            case "Default":
                switch (player.tempColour)
                {
                    case "Blue":
                        player.finalColour = CostumBlue;
                        break;
                    case "Red":
                        player.finalColour = CostumRed;
                        break;
                    case "Yellow":
                        player.finalColour = CostumYellow;
                        break;
                    default:
                        player.finalColour = Color.black;
                        break;
                }
                break;

            case "Blue":
                switch (player.tempColour)
                {
                    case "Blue":
                        player.finalColour = CostumBlue;
                        break;
                    case "Red":
                        player.finalColour = CostumPurple;
                        break;
                    case "Yellow":
                        player.finalColour = CostumGreen;
                        break;
                    default:
                        player.finalColour = CostumBlue;
                        break;
                }
                break;

            case "Yellow":
                switch (player.tempColour)
                {
                    case "Blue":
                        player.finalColour = CostumGreen;
                        break;
                    case "Red":
                        player.finalColour = CostumOrange;
                        break;
                    case "Yellow":
                        player.finalColour = CostumYellow;
                        break;
                    default:
                        player.finalColour = CostumYellow;
                        break;
                }
                break;
            case "Red":
                switch (player.tempColour)
                {
                    case "Blue":
                        player.finalColour = CostumPurple;
                        break;
                    case "Red":
                        player.finalColour = CostumRed;
                        break;
                    case "Yellow":
                        player.finalColour = CostumOrange;
                        break;
                    default:
                        player.finalColour = CostumRed;
                        break;
                }
                break;

            default:
                // Nothing for now...
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Debug info
        //Debug.Log("Player collied with " + col.gameObject.name + " @ " + Time.time);

        // On entering a colour puddle set tempColour to the appropriate colour.
        if (col.gameObject.name.Contains("BluePuddle"))
            player.tempColour = "Blue";
        else if (col.gameObject.name.Contains("RedPuddle"))
            player.tempColour = "Red";
        else if (col.gameObject.name.Contains("YellowPuddle"))
            player.tempColour = "Yellow";
    }
    void OnTriggerExit2D(Collider2D col)
    {
        // After leaving a colour puddle return tempColour to "default".
        if (col.gameObject.name.Contains("Puddle"))
            player.tempColour = "Default";
    }
}
