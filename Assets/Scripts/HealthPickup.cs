using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healingAmount = 3f;
    
    private bool pickedUp;

    private void Awake()
    {
        pickedUp = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!pickedUp && other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.Healing(healingAmount);
            pickedUp = true;
            Destroy(gameObject);
        }
    }
}
