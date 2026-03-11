using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 MoveInput;
    public bool JumpPressed;

    void Update()
    {
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");

        JumpPressed = Input.GetKeyDown(KeyCode.Space);
    }
}