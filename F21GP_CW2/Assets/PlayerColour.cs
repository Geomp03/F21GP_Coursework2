using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColour : MonoBehaviour
{
    private Material material;

    private string tempColour = "Default", baseColour = "Default";
    public Color finalColour;

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
        ChangeColour();
    }

    private void ChangeColour()
    {
        material.SetColor("_Color", finalColour);
    }

    // Evaluate Colour changes and combinations
    public void ColourEval()
    {
        switch (baseColour)
        {
            case "Default":
                switch (tempColour)
                {
                    case "Blue":
                        finalColour = CostumBlue;
                        break;
                    case "Red":
                        finalColour = CostumRed;
                        break;
                    case "Yellow":
                        finalColour = CostumYellow;
                        break;
                    default:
                        finalColour = Color.black;
                        break;
                }
                break;

            case "Blue":
                switch (tempColour)
                {
                    case "Blue":
                        finalColour = CostumBlue;
                        break;
                    case "Red":
                        finalColour = CostumPurple;
                        break;
                    case "Yellow":
                        finalColour = CostumGreen;
                        break;
                    default:
                        finalColour = CostumBlue;
                        break;
                }
                break;

            case "Yellow":
                switch (tempColour)
                {
                    case "Blue":
                        finalColour = CostumGreen;
                        break;
                    case "Red":
                        finalColour = CostumOrange;
                        break;
                    case "Yellow":
                        finalColour = CostumYellow;
                        break;
                    default:
                        finalColour = CostumYellow;
                        break;
                }
                break;
            case "Red":
                switch (tempColour)
                {
                    case "Blue":
                        finalColour = CostumPurple;
                        break;
                    case "Red":
                        finalColour = CostumRed;
                        break;
                    case "Yellow":
                        finalColour = CostumOrange;
                        break;
                    default:
                        finalColour = CostumRed;
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
        Debug.Log("Player collied with " + col.gameObject.name + " @ " + Time.time);

        // On entering a colour puddle set tempColour to the appropriate colour.
        if (col.gameObject.name.Contains("BluePuddle"))
            tempColour = "Blue";
        else if (col.gameObject.name.Contains("RedPuddle"))
            tempColour = "Red";
        else if (col.gameObject.name.Contains("YellowPuddle"))
            tempColour = "Yellow";
    }
    void OnTriggerExit2D(Collider2D col)
    {
        // After leaving a colour puddle return tempColour to "default".
        if (col.gameObject.name.Contains("Puddle"))
            tempColour = "Default";
    }
}
