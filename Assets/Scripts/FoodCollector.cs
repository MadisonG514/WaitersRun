using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodCollector : MonoBehaviour
{
    public TMP_Text collectedText; // Reference to a UI Text element for displaying collected count
    public GameObject keyPrefab; // Key prefab to spawn
    public Transform keySpawnPoint; // Location where the key will spawn
    public GameObject door; // Door to unlock
    public int totalFoodItems; // Total number of food items in the map

    private int collectedCount = 0;
    private bool keySpawned = false;

    void Start()
    {
        UpdateUI();
    }

    public void CollectFood()
    {
        collectedCount++;
        UpdateUI();

        // Check if all food items are collected
        if (collectedCount == totalFoodItems && !keySpawned)
        {
            SpawnKey();
        }
    }

    void UpdateUI()
    {
        collectedText.text = $"Food Collected: {collectedCount}/{totalFoodItems}";
    }

    void SpawnKey()
    {
        keySpawned = true;
        collectedText.text = "A key has spawned!";
        Instantiate(keyPrefab, keySpawnPoint.position, keySpawnPoint.rotation);
    }

    public void CollectKey()
    {
        UnlockDoor();
    }

    void UnlockDoor()
    {
        if (door != null)
        {
            door.SetActive(false); // Disable the door to simulate unlocking
            collectedText.text = "Door Unlocked!";
        }
    }
}
