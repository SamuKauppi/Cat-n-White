using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform gravityPoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float angleOffset = 10f;

    private float deltaAngle;

    private void FixedUpdate()
    {
        transform.up = gravityPoint.position - transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * moveSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * moveSpeed);
        }

    }
}
