using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerCollector : MonoBehaviour
{
    public GameObject winText; // Reference to the "You Won" text box
    public int totalCustomers; // Total number of customers to feed

    private int fedCustomers = 0;

    void Start()
    {
        // Ensure the win text is hidden at the start
        if (winText != null)
            winText.SetActive(false);
    }

    public void FeedCustomer()
    {
        fedCustomers++;
        if (fedCustomers == totalCustomers)
        {
            ShowWinText();
        }
    }

    void ShowWinText()
    {
        if (winText != null)
            winText.SetActive(true); // Show the win text
    }
}
