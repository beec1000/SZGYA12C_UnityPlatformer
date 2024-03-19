using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEDGEHOG_AI : MonoBehaviour
{
    [SerializeField] float runSpeed = 7f;
    [SerializeField] GameObject graphics;

    private Rigidbody2D rigidbody2d;
    private Animator animator;

    private bool facingRight = false;
    private bool canFlip = true;
    private float flipTime = 3f;
    private float flipChance = 2f;
    private float chargeTime = 2f;

    private bool isCharging = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();



    }

    private void Update()
    {
        if(Time.time > flipChance)
        {
            if (Random.Range(0, 10) >= 5)
            {
                FlipFacing();
            }
            flipChance = Time.time + flipTime;
        }
    }

    private void FlipFacing()
    {
        if (!canFlip) return;
        float facingX = graphics.transform.localScale.x;
        graphics.transform.localScale = new Vector3(
            graphics.transform.localScale.x * 1,
            graphics.transform.localScale.y,
            graphics.transform.localScale.z);
    }

}
