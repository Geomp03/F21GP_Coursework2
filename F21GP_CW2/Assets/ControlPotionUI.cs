using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPotionUI : MonoBehaviour
{
    public Sprite emptyFlask, redPotion, yellowPotion, bluePotion;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetPotionUI(bool instPotionUI, string potionColour)
    {
        gameObject.SetActive(instPotionUI);

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
