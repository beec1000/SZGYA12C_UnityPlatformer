using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private GameObject deathFX;
    [SerializeField] private Slider healthBar;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        healthBar.gameObject.SetActive(true);
        currentHealth -= damage;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            MakeDeath();
        }

    }

    private void MakeDeath()
    {
        if (gameObject.transform.parent is null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Instantiate(deathFX, transform.position, transform.rotation);
    }

}
