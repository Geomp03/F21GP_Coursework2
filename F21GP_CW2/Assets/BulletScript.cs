using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private SpriteRenderer bulletRend;

    // Costum Colours Used
    public Color CostumBlue = new Color(0.1921569f, 0.3647059f, 0.9019608f);
    public Color CostumRed = new Color(0.9372550f, 0.2470588f, 0.2509804f);
    public Color CostumYellow = new Color(0.9607844f, 0.8705883f, 0.1960784f);
    public Color CostumOrange = new Color(0.9058824f, 0.5725490f, 0.1568628f);
    public Color CostumGreen = new Color(0.2156863f, 0.9490197f, 0.0000000f);
    public Color CostumPurple = new Color(0.6823530f, 0.0784314f, 0.9686275f);

    private string tempColour = "Default", baseColour;
    private Color finalColour;


    Dictionary<Color, string> ColourDict = new Dictionary<Color, string>()
    {
        {new Color(0.1921569f, 0.3647059f, 0.9019608f), "CostumBlue"},
        {new Color(0.9372550f, 0.2470588f, 0.2509804f), "CostumRed"},
        {new Color(0.9607844f, 0.8705883f, 0.1960784f), "CostumYellow"},
        {new Color(0.9058824f, 0.5725490f, 0.1568628f), "CostumOrange"},
        {new Color(0.2156863f, 0.9490197f, 0.0000000f), "CostumGreen"},
        {new Color(0.6823530f, 0.0784314f, 0.9686275f), "CostumPurple"},
        {Color.black, "Default"}
    };


    private void Start()
    {
        bulletRend = GetComponent<SpriteRenderer>();
        baseColour = ColourDict[bulletRend.color];
        Debug.Log("Bullet Base Colour: " + baseColour);
    }

    private void Update()
    {
        // Handle colour changes
        ColourEval();
        bulletRend.color = finalColour;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On entering a colour puddle set tempColour to the appropriate colour.
        if (collision.gameObject.name.Contains("BluePuddle"))
            tempColour = "Blue";
        else if (collision.gameObject.name.Contains("RedPuddle"))
            tempColour = "Red";
        else if (collision.gameObject.name.Contains("YellowPuddle"))
            tempColour = "Yellow";

        else if (!collision.gameObject.name.Contains("Player") && !collision.gameObject.name.Contains("Bullet"))
            Destroy(gameObject);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        // After leaving a colour puddle return tempColour to "default".
        if (col.gameObject.name.Contains("BluePuddle") || col.gameObject.name.Contains("RedPuddle") || col.gameObject.name.Contains("YellowPuddle"))
            tempColour = "Default";
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

            case "CostumBlue":
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

            case "CostumYellow":
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
            case "CostumRed":
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
                finalColour = bulletRend.color;
                break;
        }
    }
}
    