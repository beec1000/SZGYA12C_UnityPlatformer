using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage = 2f;
    [SerializeField] private float damageRate = 1f;
    [SerializeField] private float pushForce = 20f;

    private float nextDamage;

    private void Start()
    {
        nextDamage = 0f;
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.CompareTag("Player") && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = player.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            nextDamage = Time.time + damageRate;

            PushBack(player.transform);

        }
    }

    private void PushBack(Transform playerTransform) 
    {
        Vector2 pushDirection = new Vector2(
            playerTransform.position.x - transform.position.x, 
            playerTransform.position.y - transform.position.y) * pushForce;
        Rigidbody2D playerRB = playerTransform.gameObject.GetComponent<Rigidbody2D>();
        playerRB.velocity = Vector2.zero;
        playerRB.AddForce(pushDirection, ForceMode2D.Impulse);

    }

}
