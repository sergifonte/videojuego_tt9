using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 8f;
    public float gravity = -20f;
    public float rotationSpeed = 10f;

    [Header("Audio Settings")]
    public AudioClip walkSound;
    public AudioClip jumpSound;
    [Range(0.1f, 2f)] public float footstepInterval = 0.5f;

    private CharacterController controller;
    private InputHandler input;
    private AudioSource audioSource;

    private Vector3 velocity;
    private float footstepTimer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputHandler>();
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void Update()
    {
        HandleMovement();
        ApplyGravity();
        HandleFootsteps();
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(input.MoveInput.x, 0, input.MoveInput.y);
        Transform cam = Camera.main.transform;
        Vector3 camForward = cam.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cam.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 moveDirection = camForward * move.z + camRight * move.x;

        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (controller.isGrounded && input.JumpPressed)
        {
            velocity.y = jumpForce;
            PlaySound(jumpSound);
        }

        Vector3 finalMove = moveDirection * speed + new Vector3(0, velocity.y, 0);
        controller.Move(finalMove * Time.deltaTime);
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
    }

    void HandleFootsteps()
    {
        bool isMoving = new Vector2(input.MoveInput.x, input.MoveInput.y).sqrMagnitude > 0.01f;

        if (controller.isGrounded && isMoving)
        {
            footstepTimer += Time.deltaTime;

            if (footstepTimer >= footstepInterval)
            {
                PlaySound(walkSound);
                footstepTimer = 0f;
            }
        }
        else
        {
            footstepTimer = footstepInterval;
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}