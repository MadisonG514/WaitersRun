using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Customer : MonoBehaviour
{
    public Sprite fedSprite; // Sprite to display once the customer is fed

    private bool isFed = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided
        CustomerCollector player = other.GetComponent<CustomerCollector>();
        if (player != null && !isFed)
        {
            isFed = true; // Mark the customer as fed
            UpdateSprite();
            player.FeedCustomer(); // Notify the player script
        }
    }

    void UpdateSprite()
    {
        if (fedSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = fedSprite; // Change the customer's sprite to the fed sprite
        }
    }
}
