using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    Vector3 forward, strafe, vertical;
    public float run = 15f;
    public float speedF = 5f;
    public float strafeSpeed = 5f;
    public float gravity = 9.80665f;
    public float jumpSpeed = 3.2f;
    public float maxJumpH = 2f;
    public float timeToMaxH = 0.3f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gravity = (-2 * maxJumpH) / (timeToMaxH * timeToMaxH);
        jumpSpeed = (2 * maxJumpH) / timeToMaxH;
    }

    void Update()
    {
        float fInput = Input.GetAxisRaw("Vertical");
        float sInput = Input.GetAxisRaw("Horizontal");

        forward = fInput * speedF * transform.forward;
        strafe = sInput * strafeSpeed * transform.right;
        vertical += gravity * Time.deltaTime * Vector3.up;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            forward = fInput * (run) * transform.forward;
            strafe = sInput * (run) * transform.right;
        }

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        Vector3 finalVelocity = forward + strafe + vertical;
        controller.Move(finalVelocity * Time.deltaTime);
    }
}
