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
        //Ens assegurem que no falti ningun component
        if (anim == null || controller == null || input == null) return;

        // Walking Animation s'activa
        bool walking = input.MoveInput.magnitude > 0.1f;
        anim.SetBool("isWalking", walking);

        //Control si toca el terra o no
        anim.SetBool("isGrounded", controller.isGrounded);

        //Trigger per saltar
        if (controller.isGrounded && input.JumpPressed)
        {
            anim.SetTrigger("Jump");
        }
    }
}