using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart, emptyHeart;

    public void SetMaxHealth(int maxHealth)
    {
        // Load heart sprites appropriately
        for (int i = 0; i < hearts.Length; i++)
        {
            // Enable or disale image object depending on player health
            if (i < maxHealth)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    public void SetHealth(int currentHealth)
    {
        // Load heart sprites appropriately
        for (int i = 0; i < hearts.Length; i++)
        {
            // Full heart sprite or empty heart sprite depending on current health
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
