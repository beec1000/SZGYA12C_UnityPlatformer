using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private bool canDrop = true;
    [SerializeField] private float dropChance = 70f;

    [SerializeField] private GameObject deathFX;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject healthDrop;

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
        Instantiate(deathFX, transform.position, transform.rotation);
        if (canDrop && Random.Range(0, 100) < dropChance)
        {
            Instantiate(healthDrop, transform.position, transform.rotation);
        }

        if (gameObject.transform.parent is not null) Destroy(gameObject.transform.parent.gameObject);
        else Destroy(gameObject);
        
    }
}