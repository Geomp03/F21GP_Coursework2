using System.Collections;
using UnityEngine;

public class MechaGolem : MonoBehaviour
{
    // Boss properties
    public int maxHealth;
    public float attackCooldown;
    public Material bossMaterial; // Assign the shader material in the Unity Inspector

    private int currentHealth;
    private Animator animator;
    private Color currentColor;
    private Color[] baseColors = { Color.red, Color.blue, Color.yellow };
    private Color[] mixedColors = { Color.green, Color.magenta, Color.cyan };
    private int phase;
    private Coroutine attackRoutine;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        phase = 1;
        StartCoroutine(ColorCycle());
    }

    void Update()
    {
        // Check for phase transitions based on health percentage
        if (phase == 1 && currentHealth <= maxHealth * 0.66f)
        {
            phase = 2;
            StopCoroutine(ColorCycle());
            StartCoroutine(ColorCycleMixed());
        }
        else if (phase == 2 && currentHealth <= maxHealth * 0.33f)
        {
            phase = 3;
            StopCoroutine(ColorCycleMixed());
            StartCoroutine(GlowingFury());
        }
    }

    private IEnumerator ColorCycle()
    {
        while (true)
        {
            for (int i = 0; i < baseColors.Length; i++)
            {
                currentColor = baseColors[i];
                UpdateBossMaterial();
                if (attackRoutine == null)
                {
                    attackRoutine = StartCoroutine(Attack());
                }
                yield return new WaitForSeconds(3); // Wait for 3 seconds before switching colors
            }
        }
    }

    private IEnumerator ColorCycleMixed()
    {
        while (true)
        {
            for (int i = 0; i < mixedColors.Length; i++)
            {
                currentColor = mixedColors[i];
                UpdateBossMaterial();
                if (attackRoutine == null)
                {
                    attackRoutine = StartCoroutine(Attack());
                }
                yield return new WaitForSeconds(3); // Wait for 3 seconds before switching colors
            }
        }
    }

    private IEnumerator GlowingFury()
    {
        while (true)
        {
            for (int i = 0; i < baseColors.Length + mixedColors.Length; i++)
            {
                currentColor = i < baseColors.Length ? baseColors[i] : mixedColors[i - baseColors.Length];
                UpdateBossMaterial();
                if (attackRoutine == null)
                {
                    attackRoutine = StartCoroutine(Attack());
                }
                yield return new WaitForSeconds(1); // Wait for 1 second before switching colors
            }
        }
    }

    private void UpdateBossMaterial()
    {
        bossMaterial.SetColor("_Color", currentColor);
    }

    private IEnumerator Attack()
    {
        // Execute attack animation based on phase and current color
        // You can customize the attack logic for different colors and phases here
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attackCooldown);
        attackRoutine = null;
    }

}