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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    /*private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }*/
}

