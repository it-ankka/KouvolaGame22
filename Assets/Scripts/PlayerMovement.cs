using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Character components
    private CharacterController controller;

    // Character movement properties
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float fallDamageHeight = 10f;

    // Ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Character movement variables
    Vector3 velocity;
    bool isGrounded;
    float stepOffset;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        stepOffset = controller.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            controller.stepOffset = stepOffset;
            FallDamageHandler();
            velocity.y = -2f;
        }
        else if (isGrounded)
        {
            controller.stepOffset = stepOffset;
        }
        else if (!isGrounded)
        {
            controller.stepOffset = 0;
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = Vector3.Normalize(transform.right * x + transform.forward * z);

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButton("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void FallDamageHandler()
    {
        float fallHeight = Mathf.Pow(velocity.y, 2) / -2f / gravity;
        if (fallHeight > fallDamageHeight)
        {
            int damage = (int)((fallHeight - fallDamageHeight) * 20);
            Debug.Log("Damaged player for: " + damage);
        }
    }
}
