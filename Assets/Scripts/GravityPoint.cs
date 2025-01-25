using System.Collections;
using System.Collections.Generic;
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
                gravity = Vector3.down * gravityScale;
            Physics2D.gravity = gravity;
        }
        else if (Vector3.Distance(playerRb.position, swapPosition) > swapDist)
        {
            isSwapping = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && !isSwapping)
        {
            SwapGravity();
        }
    }

    public void SwapGravity()
    {
        isSwapping = true;
        swapPosition = playerTarget.position;
        swapDirection = transform.position - swapPosition;
        Physics2D.gravity = swapDirection;
        swapDist = Vector3.Distance(swapPosition, transform.position) * 1.5f;
        playerRb.AddForce(playerTarget.up * 10f);
    }
}
