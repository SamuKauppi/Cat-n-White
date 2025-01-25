using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform gravityPoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxSpeed = 10f;

    private void FixedUpdate()
    {
        transform.up = gravityPoint.position - transform.position;
        rb.rotation = transform.up.z;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(moveSpeed * Time.fixedDeltaTime * -transform.right);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(moveSpeed * Time.fixedDeltaTime * transform.right);
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Player Dies");
    }
}
