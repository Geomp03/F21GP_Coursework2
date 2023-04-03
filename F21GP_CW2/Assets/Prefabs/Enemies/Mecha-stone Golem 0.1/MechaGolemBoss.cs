using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaGolemBoss : MonoBehaviour
{
    public enum BossState { ColorCycle, ColorMixing, GlowingFury, Defeated }
    public enum BossColor { Red, Blue, Yellow, Green, Orange, Purple, None }

    public BossState currentState;
    public BossColor currentColor;

    // Health and damage variables
    public int maxHealth = 100;
    private int currentHealth;

    // Color change delay
    public float colorChangeDelay = 2f;

    // Reference to the player object and its color
    public GameObject player;
    public Material bossMaterial;

    //private WizardColor playerColorScript;

    // Animators for the Mecha Golem 
    public Animator golemAnimator;

    void Start()
    {
        currentHealth = maxHealth;
        currentState = BossState.ColorCycle;
        currentColor = BossColor.None;
        //playerColorScript = player.GetComponent<WizardColor>();

        StartCoroutine(ColorChangeRoutine());
    }

    void Update()
    {
        if (currentState != BossState.Defeated && currentHealth <= 0)
        {
            currentState = BossState.Defeated;
            StartCoroutine(DefeatRoutine());
        }
    }

    IEnumerator ColorChangeRoutine()
    {
        while (currentState != BossState.Defeated)
        {
            switch (currentState)
            {
                case BossState.ColorCycle:
                    CycleBasicColors();
                    break;
                case BossState.ColorMixing:
                    CycleMixedColors();
                    break;
                case BossState.GlowingFury:
                    CycleAllColors();
                    break;
            }
            UpdateColorOutline();
            yield return new WaitForSeconds(colorChangeDelay);
        }
    }

    void CycleBasicColors()
    {
        // Cycle through Red, Blue, and Yellow colors
    }

    void CycleMixedColors()
    {
        // Cycle through Green, Orange, and Purple colors
    }

    void CycleAllColors()
    {
        // Rapidly cycle through all colors (Red, Blue, Yellow, Green, Orange, and Purple)
    }

    void UpdateColorOutline()
    {
        // Update the color outline animator based on the currentColor value
    }

    public void TakeDamage(int damage)
    {
        // Check if the player's color matches the boss's color
        //if (playerColorScript.currentColor == currentColor)
        //{
        //    currentHealth -= damage;
        //}
    }

    IEnumerator DefeatRoutine()
    {
        // Play the death animation and disable the boss object
        golemAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
