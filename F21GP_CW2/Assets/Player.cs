using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Components used
    private Rigidbody2D    playerRB;
    private SpriteRenderer playerRend;

    public EmptyFlask SpawnEmptyFlask;
    public ControlPotionUI PotionUI;

    public MessageDisp canvasText;
    public IEnumerator coroutine;

    public HealthSystem healthSystem;

    [SerializeField] float speed, shootForce;
    private float DirX, DirY;
    private string tempColour = "Default", baseColour = "Default", potionColour = "Default";
    //private Color finalColour;
    private bool holdingFlask;
    public int currentHealth, maxHealth;

    private PlayerAim playerAim;

    

    

    // Start is called before the first frame update
    private void Start()
    {
        // Initialise all components needed...
        playerRB   = GetComponent<Rigidbody2D>();
        playerRend = GetComponent<SpriteRenderer>();

        holdingFlask = false;

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


        // Ensure current player health never goes above the max player health
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;


        // Handle colour changes
        //ColourEval();
        //playerRend.color = finalColour;

        // Potion mechanic

        if (Input.GetButtonDown("UseItem")) // U key
            PotionColours();

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    TakeDamage(1); // Lose health???
        //}
    }


    // Collisions
    void OnTriggerEnter2D(Collider2D col)
    {
    
        // Pickup empty flask
        if (col.gameObject.name.Contains("EmptyFlask"))
        {
            holdingFlask = true;
            PotionUI.InstPotionUI(holdingFlask);
            Debug.Log("Holding empty flask");
        }

        else if (col.gameObject.name.Contains("Enemy"))
        {
            TakeDamage(1); // Lose health???
        }

        else if (col.gameObject.name == "Subroom 2")
            SpawnEmptyFlask.SpawnPotion();
    }

    

    // Potion Mechanic
    private void PotionColours()
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
            if (tempColour == "Default")
            {
                // UI message to warn player to step on a colour puddle to make potions
                Debug.Log("Not on colour puddle");
                coroutine = canvasText.UIMessages("Step on a colour puddle to create a potion", 2);
                StartCoroutine(coroutine);
            }
            else
            {
                potionColour = tempColour;  // Set flask colour to whatever the temporary colour is...
                Debug.Log("Potion colour is: " + potionColour);
            }
        }

        // When holding a flask with a coloured potion
        else if (holdingFlask == true && potionColour != "Default")
        {
            baseColour = potionColour;  // Set player base colour to whatever the potion is
            potionColour = "Default";   // Reset potion to default ie empty the flask
            Debug.Log("Player base colour changed to " + baseColour + " and Potion colour is back to " + potionColour);
        }

        PotionUI.InstPotionUI(holdingFlask);
        PotionUI.SetPotionUI(potionColour);
    }


    private void TakeDamage(int damage)
    {
        currentHealth = currentHealth - 1;
        healthSystem.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            // Death!!!
        }
    }

    
}
