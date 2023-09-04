using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float playerJumpSpeed = 10f;
    [SerializeField] private float playerCounterSpeedMultiplier = 0.15f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 playereulerAngleVelocity = new Vector3(0, 150, 0);

    private void Update()
    {
        Vector3 facingDown = -transform.up;
        Boolean canAction = true;

        // Touching The Ground
        if (Physics.Raycast(transform.position, facingDown, transform.localScale.y/2 + 0.01f))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.forward.normalized * playerSpeed * Time.deltaTime * 100);
                limitSpeed("W");
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.forward.normalized * playerSpeed * Time.deltaTime * 100);
                limitSpeed("S");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * playerJumpSpeed, ForceMode.Impulse);
            }
        }
        // If a side is touching the ground thats not the bottom
        else if (Physics.Raycast(transform.position, -Vector3.up, transform.localScale.y / 2 + 1f) && !Physics.Raycast(transform.position, facingDown, transform.localScale.y / 2 + 1f))
        {
            canAction = false;
        }
        if(canAction)
        {
        if (Input.GetKey(KeyCode.D))
        {
                //transform.Rotate(0, 2.5f, 0);
                rotateObject("r");
        }
        if (Input.GetKey(KeyCode.A))
        {
                //transform.Rotate(0, -2.5f, 0);
                rotateObject("l");
            }
        }
    }

    private void limitSpeed(String dirn)
    {
        float velX = rb.velocity.x;
        float velZ = rb.velocity.z;
        float velOverall = Mathf.Sqrt(Mathf.Pow(velX, 2) + Mathf.Pow(velZ, 2));

        if(velOverall > maxSpeed && dirn == "W")
        {
            rb.AddForce(-transform.forward * Mathf.Sqrt(velOverall) * playerCounterSpeedMultiplier * 100);
        }
        if (velOverall > maxSpeed && dirn == "S")
        {
            rb.AddForce(transform.forward * Mathf.Sqrt(velOverall) * playerCounterSpeedMultiplier * 100);
        }
    }

    private void rotateObject(String dirn)
    {
        Quaternion deltaRotation;

        if (dirn == "r")
        {
            deltaRotation = Quaternion.Euler(playereulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        else if (dirn == "l")
        {
            deltaRotation = Quaternion.Euler(playereulerAngleVelocity * -Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

}
