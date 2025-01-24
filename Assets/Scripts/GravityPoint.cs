using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float gravity = 9.81f;

    Vector3 gravityDirection;

    // Update is called once per frame
    void Update()
    {
        gravityDirection = (playerTarget.position - transform.position).normalized * gravity;
        Physics2D.gravity = gravityDirection;
    }
}
