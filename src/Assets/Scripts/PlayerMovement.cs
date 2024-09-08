using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    float ogSpeed = 0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    bool sprinting = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    LayerMask groundMask;
    LayerMask jumpMask;
    LayerMask killMask;
    LayerMask bouncyMask;
    LayerMask slowMask;

    Vector3 velocity;
    Vector3 forward;


    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        bool isJumpable = Physics.CheckSphere(groundCheck.position, groundDistance, jumpMask);
        bool isDead = Physics.CheckSphere(groundCheck.position, groundDistance, killMask);
        bool isBouncy = Physics.CheckSphere(groundCheck.position, groundDistance + .5f, bouncyMask);
        bool isSlow = Physics.CheckSphere(groundCheck.position, groundDistance, slowMask);

        if (isDead)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        if (isBouncy) {
            velocity.y += 3f;
            velocity.y *= -0.9f;
            if (velocity.y < 0f)
                velocity.y *= -1f;
        }

        if (isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            speed = ogSpeed + 5f;
            sprinting = true;
        }
        else if (isGrounded)
            sprinting = false;

        if (isSlow)
            speed = ogSpeed - 5f;
        else if (!sprinting)
            speed = ogSpeed;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        forward = transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 move = transform.right * x + forward * z;
        move.y = 0;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isJumpable)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        else if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Start()
    {
        groundMask = LayerMask.GetMask(new string[] { "Default", "WaterBounce" });
        jumpMask = LayerMask.GetMask(new string[] { "Default" });
        killMask = LayerMask.GetMask(new string[] { "Water" });
        bouncyMask = LayerMask.GetMask(new string[] { "Bouncy" });
        slowMask = LayerMask.GetMask(new string[] { "WaterBounce" });

        ogSpeed = speed;
    }
}