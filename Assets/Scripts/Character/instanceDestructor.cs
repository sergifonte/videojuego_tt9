using UnityEngine;

public class instanceDestructor : MonoBehaviour
{
    public GameObject character;
    public GameObject waxBall; 
    public bool isColliding = false; 
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isColliding)
        {
            Destroy(waxBall); 
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
