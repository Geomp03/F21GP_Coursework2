using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPotionUI : MonoBehaviour
{
    public Sprite emptyFlask, redPotion, yellowPotion, bluePotion;
    public Image image;

    public void InstPotionUI(bool instPotionUI)
    {
        // gameObject.SetActive(instPotionUI);
        image.enabled = instPotionUI;
    }    

    public void SetPotionUI(string potionColour)
    {
        switch (potionColour)
        {
            case "Default":
                image.sprite = emptyFlask;
                break;

            case "Blue":
                image.sprite = bluePotion;
                break;

            case "Red":
                image.sprite = redPotion;
                break;

            case "Yellow":
                image.sprite = yellowPotion;
                break;

            default:
                // Nothing??
                break;
        } 
    }
}
