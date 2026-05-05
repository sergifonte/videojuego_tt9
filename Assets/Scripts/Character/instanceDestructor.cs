using UnityEngine;

public class instanceDestructor : MonoBehaviour
{
    public bool isColliding = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isColliding)
        {
            Instance.instance.index--;  
            Instance.instance.size();
            Destroy(gameObject);         
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
        //else { isColliding = false;  }
    }

    /*private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }*/
}

