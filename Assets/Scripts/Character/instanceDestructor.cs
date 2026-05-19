using UnityEngine;

public class instanceDestructor : MonoBehaviour
{
    public Instance link; //enllaç amb la variable isColliding de l'script Instance

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && link.isColliding)
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
            link.isColliding = true;
            Debug.Log("Col·lisió instància-jugador"); 
        }
        else
        {
            link.isColliding = false; 
        }
    }

}

