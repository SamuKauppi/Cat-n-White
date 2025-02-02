using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform gravityPoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private LayerMask bubbleLayer;
    [SerializeField] private Vector2 respwan;

    private Vector2 direction;

    private float angle;
    public bool IsEnabled { get; private set; } = true;

    private void Start()
    {
        respwan = transform.position;
    }

    private void FixedUpdate()
    {
        CalculateAngle();

        if (IsEnabled)
            CheckInput();

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
    private void CalculateAngle()
    {
        direction = gravityPoint.position - transform.position;
        angle = Vector2.Angle(direction, transform.up);
        float cross = Vector3.Cross(direction, transform.up).z;


        if (cross < 0)
        {
            angle = -angle;
        }

        if (Mathf.Abs(angle) > 0.1f)
        {
            rb.rotation = rb.rotation - angle;
        }
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddForce(moveSpeed * Time.fixedDeltaTime * -transform.right);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(moveSpeed * Time.fixedDeltaTime * transform.right);
        }
    }


    public void SetRespawn()
    {
        respwan = transform.position;
    }
    public void KillPlayer()
    {
        transform.position = respwan;
        rb.velocity = Vector2.zero;
        SetPlayerEnable(false);
    }

    public void SetPlayerEnable(bool value)
    {
        IsEnabled = value;
        rb.isKinematic = !value;
    }
}
