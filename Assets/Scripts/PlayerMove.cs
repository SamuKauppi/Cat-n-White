using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform gravityPoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxSpeed = 10f;

    Vector2 direction;
    private float angle;

    private void FixedUpdate()
    {
        CalculateAngle();
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(moveSpeed * Time.fixedDeltaTime * -transform.right);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(moveSpeed * Time.fixedDeltaTime * transform.right);
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Player Dies");
    }
}
