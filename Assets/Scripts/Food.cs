using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided
        FoodCollector player = other.GetComponent<FoodCollector>();
        if (player != null)
        {
            player.CollectFood(); // Notify the player script
            Destroy(gameObject); // Destroy the food item
        }
    }
}
