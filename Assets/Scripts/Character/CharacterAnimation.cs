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
        //Ens assegurem que no falti cap component
        if (anim == null || controller == null || input == null) return;

        //Walking Animation s'activa
        bool walking = input.MoveInput.magnitude > 0.1f;
        anim.SetBool("isWalking", walking);

        //Control si toca el terra o no (per a les transicions de caiguda)
        anim.SetBool("isGrounded", controller.isGrounded);

        //Trigger per saltar segur
        if (input.JumpPressed)
        {
            //Mirem què està fent l'Animator
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);

            //Permetem saltar si estem a l'aire (Loop) o tocant terra (Landing)
            bool isJumping = state.IsName("JumpStart");

            if (!isJumping)
            {
                anim.SetTrigger("Jump");
            }
        }
    }
}