using Unity.Mathematics;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 7;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private bool isFacingRight;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        isFacingRight = true;

    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));

        rigidbody2d.velocity = new Vector2(
            x: move * maxSpeed,
            y: rigidbody2d.velocity.y);

        if ((move < 0 && isFacingRight) || (move > 0 && !isFacingRight)) Flip();

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(
            x: transform.localScale.x * -1,
            y: transform.localScale.y);


    }
}