using UnityEngine;

public class HedgehogAI : MonoBehaviour
{
    [SerializeField] GameObject graphics;

    [SerializeField] float runSpeed = 7f;
    [SerializeField] private float startChargeTime = 0f;
    [SerializeField] private float chargeDelay = .25f;

    private Animator animator;
    private Rigidbody2D rigidbody2d;

    private bool facintgRight = false;
    private bool canFlip = true;
    private bool isCharging = false;

    private float flipTime = 2f;
    private float nextFlip = 0f;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canFlip && Time.time > nextFlip)
        {
            if (Random.Range(0, 10) >= 5) FlipFacing();
            nextFlip = Time.time + flipTime;
        }

        animator.SetBool("isCharging", isCharging);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (facintgRight != other.transform.position.x > transform.position.x) 
                FlipFacing();
            canFlip = false;
            isCharging = true;
            startChargeTime = Time.time + chargeDelay;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isCharging && Time.time > startChargeTime && other.CompareTag("Player"))
        {
            rigidbody2d.AddForce(new Vector2(x: facintgRight ? +1 : -1, y: 0) * runSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCharging = false;
            canFlip = true;

            rigidbody2d.velocity = Vector2.zero;
        }
    }

    private void FlipFacing()
    {
        facintgRight = !facintgRight;
        graphics.transform.localScale =
            new Vector3(
                graphics.transform.localScale.x * -1,
                graphics.transform.localScale.y,
                graphics.transform.localScale.z);
    }
}