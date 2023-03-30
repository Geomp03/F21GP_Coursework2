using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Components used
    private Rigidbody2D    playerRB;
    //private SpriteRenderer playerRend;

    public PlayerRespawn playerRespawn;

    //public EmptyFlask SpawnEmptyFlask;
    public PotionScript potionScript;

    //public MessageDisp canvasText;
    //public IEnumerator coroutine;

    public HealthSystem healthSystem;

    [SerializeField] float speed;
    private float DirX, DirY;
    [HideInInspector] public string tempColour, baseColour, potionColour;
    [HideInInspector] public Color finalColour;

    public int currentHealth, maxHealth;

    //private PlayerAim playerAim;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialise all components needed...
        playerRB   = GetComponent<Rigidbody2D>();
        //playerRend = GetComponent<SpriteRenderer>();

        playerRespawn = FindObjectOfType<PlayerRespawn>();

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
        {
            TakeDamage(1); // Lose health???
        }
    }

    // Damage & Death
    private void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        // Check for death
        if (currentHealth == 0)
            playerRespawn.Respawn();  // On death...
    }


}
