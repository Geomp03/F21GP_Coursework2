using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Components used
    private Rigidbody2D    playerRB;
    //private SpriteRenderer playerRend;

    private PotionScript potionScript;
    private HealthSystem healthSystem;
    public  GameOverScreen gameOver;
    private SoundEffectSource audioSource;

    [SerializeField] float speed;
    private float DirX, DirY;


    [HideInInspector] public string tempColour, baseColour, potionColour;
    [HideInInspector] public Color finalColour;

    [SerializeField] private AudioClip hurtClip, deathClip;

    public int currentHealth, maxHealth;

    //private PlayerAim playerAim;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialise all components needed...
        playerRB   = GetComponent<Rigidbody2D>();
        //playerRend = GetComponent<SpriteRenderer>();
        potionScript  = FindObjectOfType<PotionScript>();
        healthSystem  = FindObjectOfType<HealthSystem>();
        // gameOver      = FindObjectOfType<GameOverScreen>();
        audioSource = FindObjectOfType<SoundEffectSource>();

        // Start with default colour and no flask
        tempColour   = "Default";
        baseColour   = "Default";

        // Instantiate health system
        currentHealth = maxHealth;
        healthSystem.SetMaxHealth(maxHealth);
        healthSystem.SetHealth(currentHealth);
    }


    // Update is called once per frame
    private void Update()
    {
        // Movement
        DirX = Input.GetAxis("Horizontal");
        DirY = Input.GetAxis("Vertical");
        
        playerRB.velocity = new Vector2(DirX * speed, DirY * speed);

        
        // Ensure current player health never goes above max health
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        // Update player health bar graphic
        healthSystem.SetHealth(currentHealth);

        // Potion mechanic
        if (Input.GetButtonDown("UseItem")) // U key
            potionScript.PotionColours();
    }


    // Collisions
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
            TakeDamage(1); // Lose health???
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            TakeDamage(1); // Lose health???
    }

    // Damage & Death
    private void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        audioSource.PlaySoundEffect(hurtClip);

        // Check for death
        if (currentHealth == 0)
        {
            audioSource.PlaySoundEffect(deathClip);
            gameOver.InitializeGameOverScreen();
        }
    }


}
