using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float gravityScale = 9.81f;

    private Vector3 gravity;

    // Direction swapping
    private bool isSwapping = false;
    private Vector3 swapPosition;
    private Vector3 swapDirection;
    private float swapDist;

    private void Update()
    {
        if (!isSwapping)
        {
            gravity = gravityScale * (playerTarget.position - transform.position).normalized;
            if (Mathf.Abs(gravity.magnitude) == 0f)
                gravity = gravityScale * Vector3.down;
            Physics2D.gravity = gravity;
        }
        else if (Vector3.Distance(playerRb.position, swapPosition) > swapDist)
        {
            isSwapping = false;
        }
    }

    public void SwapGravity()
    {
        isSwapping = true;
        swapPosition = playerTarget.position;
        swapDirection = transform.position - swapPosition;
        Physics2D.gravity = 1.5f * gravityScale * swapDirection;
        swapDist = Vector3.Distance(swapPosition, transform.position) * 1.5f;
    }
}
