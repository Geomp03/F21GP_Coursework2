using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public Player player;

    public ControlPotionUI PotionUI;
    public MessageDisp canvasText;
    public IEnumerator coroutine;

    private string potionColour = "Default";
    private bool holdingFlask = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pickup empty flask
        if (collision.gameObject.name.Contains("EmptyFlask"))
        {
            holdingFlask = true;
            PotionUI.InstPotionUI(holdingFlask);
            Debug.Log("Holding empty flask");
        }
    }

    // Potion Mechanic
    public void PotionColours()
    {
        // When not holding an empty flask
        if (holdingFlask == false)
        {
            // Warn player they're not holding any items to use (maybe add sound as well).
            Debug.Log("Not holding an item");
            coroutine = canvasText.UIMessages("Not holding an item to use", 2);
            StartCoroutine(coroutine);
        }

        // When holding an empty flask
        else if (holdingFlask == true && potionColour == "Default")
        {
            if (player.tempColour == "Default")
            {
                // UI message to warn player to step on a colour puddle to make potions
                Debug.Log("Not on colour puddle");
                coroutine = canvasText.UIMessages("Step on a colour puddle to create a potion", 2);
                StartCoroutine(coroutine);
            }
            else
            {
                potionColour = player.tempColour;  // Set flask colour to whatever the temporary colour is...
                Debug.Log("Potion colour is: " + potionColour);
            }
        }

        // When holding a flask with a coloured potion
        else if (holdingFlask == true && potionColour != "Default")
        {
            player.baseColour = potionColour;  // Set player base colour to whatever the potion is
            potionColour = "Default";   // Reset potion to default ie empty the flask
            Debug.Log("Player base colour changed to " + player.baseColour + " and Potion colour is back to " + potionColour);
        }

        PotionUI.InstPotionUI(holdingFlask);
        PotionUI.SetPotionUI(potionColour);
    }
}
