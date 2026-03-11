using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 8f;
    public float gravity = -20f;
    public float rotationSpeed = 10f;

    private CharacterController controller;
    private InputHandler input;

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputHandler>();
    }

    void Update()
    {
        Move();
        Jump();
        ApplyGravity();
    }

    void Move()
    {
        Vector3 move = new Vector3(input.MoveInput.x, 0, input.MoveInput.y);

        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        controller.Move(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (controller.isGrounded && input.JumpPressed)
            velocity.y = jumpForce;
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}