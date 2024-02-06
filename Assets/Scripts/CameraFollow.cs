using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float delay = 5f;

    private Vector3 offsetRight;
    private Vector3 offsetLeft;
    private float lowY;
    private bool facingRight;
    private float difX;

    private void Start()
    {
        facingRight = true;
        difX = transform.position.x - target.position.x;
        lowY = transform.position.y;
        offsetRight = transform.position - target.position;
        offsetLeft = transform.position - target.position;
        offsetLeft.x -= 2 * difX;

    }

    private void FixedUpdate()
    {
        Vector3 targetPos = target.localScale.x > 0
            ? target.position + offsetRight
            : target.position + offsetLeft;
        transform.position = Vector3.Lerp(transform.position, targetPos, delay * Time.deltaTime);

        if (transform.position.y < lowY)
        {
            transform.position = new(transform.position.x, lowY, transform.position.z);
        }

    }
}
