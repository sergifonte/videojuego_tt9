using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private InputHandler input;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputHandler>();
    }

    void Update()
    {
        if (anim == null || controller == null || input == null) return;

        //walking Animation 
        bool walking = input.MoveInput.magnitude > 0.1f;
        anim.SetBool("isWalking", walking);

        anim.SetBool("isGrounded", controller.isGrounded);

        if (input.JumpPressed)
        {
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);

            bool isJumping = state.IsName("JumpStart");

            if (!isJumping)
            {
                anim.SetTrigger("Jump");
            }
        }
    }
}