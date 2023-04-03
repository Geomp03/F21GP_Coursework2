using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourScript : MonoBehaviour
{
    public Player player;
    private PlayerColour playerColour;
    private Material material;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        playerColour = FindObjectOfType<PlayerColour>();
        material = GetComponent<SpriteRenderer>().sharedMaterial;
    }

    void Start()
    {
    }


    void Update()
    {
        material.SetColor("_Color", player.finalColour);
    }
}
