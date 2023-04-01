using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Player player;

    private ControlKeyUI KeyUI;
    private MessageDisp canvasText;
    public IEnumerator coroutine;
    private SoundEffectSource audioSource;
    [SerializeField] private AudioClip doorUnlocked, doorLocked;

    public bool holdingKey;

    private void Start()
    {
        // Get all necessary components
        KeyUI = FindObjectOfType<ControlKeyUI>();
        canvasText = FindObjectOfType<MessageDisp>();
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pickup key
        if (collision.gameObject.name.Contains("Key"))
        {
            holdingKey = true;
            KeyUI.InstKeyUI(holdingKey);
            Debug.Log("Holding key");
        }
    }

    // Key Mechanic
    public void UseKey()
    {
        if (holdingKey == true)
        {
            holdingKey = false;                         // Key is used up
            KeyUI.InstKeyUI(holdingKey);
            audioSource.PlaySoundEffect(doorUnlocked);  // Player appropriate sound effect
            Debug.Log("Not holding key");
        }
        else
        {
            coroutine = canvasText.UIMessages("Need a key to open this door", 2);
            StartCoroutine(coroutine);
            audioSource.PlaySoundEffect(doorLocked);  // Player appropriate sound effect
        }
    }    
}
