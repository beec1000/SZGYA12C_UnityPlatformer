using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 15f;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(
            x: transform.rotation.z == 0 ? +projectileSpeed : -projectileSpeed, 0), 
            ForceMode2D.Impulse);

    }

    public void Stop() => rigidbody2D.velocity = new(0, 0);

}
