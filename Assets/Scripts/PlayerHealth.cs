using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private GameObject bloodDropsFX;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image damageIndicator;
    [SerializeField] private float dmgSmoothTime = .5f;

    private Color dmgColor = new Color(255f, 0f, 0f, .7f);
    private float currentHealth;
    private bool getDamage;

    private void Start()
    {
        getDamage = false;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    private void Update()
    {
        if (getDamage)
        {
            damageIndicator.color = dmgColor;
            getDamage = false;
        }
        else
        {
            damageIndicator.color = Color.Lerp(damageIndicator.color, new Color(255f, 255f, 255f, 0f), dmgSmoothTime * Time.deltaTime);
            
        }
        

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        getDamage = true;
        healthBar.value = currentHealth;
        Instantiate(bloodDropsFX, transform.position, transform.rotation);
        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }

    private void MakeDead()
    {
        Destroy(gameObject);
        //damageIndicator.color = new(255f, 255f, 255f, 1f);
    }

}
