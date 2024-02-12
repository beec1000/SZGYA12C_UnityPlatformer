using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHit : MonoBehaviour
{
    [SerializeField] private float damage = 2f;
    [SerializeField] private GameObject explosionEffect;

    private ProjectileController controller;

    private void Awake()
    {
        controller = GetComponentInParent<ProjectileController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Hitable"))
        {
            controller.Stop();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            //Destroy(target.gameObject);
            if (target.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = target.gameObject.GetComponent;
            }
        }
    }

}
