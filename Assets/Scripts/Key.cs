using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided
        FoodCollector player = other.GetComponent<FoodCollector>();
        if (player != null)
        {
            player.CollectKey(); // Notify the player script
            Destroy(gameObject); // Destroy the key
        }
    }
}
