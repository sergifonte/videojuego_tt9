using UnityEngine;

public class instanceDestructor : MonoBehaviour
{
    //public Instance link; //enllaç amb la variable isColliding de l'script Instance
    private bool playerIsClose = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            Instance.instance.index--;  
            Instance.instance.size();
            Instance.instance.isColliding = false;
            Destroy(gameObject);         
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            Instance.instance.isColliding = true; // Avisem al script de l'Emma
            Debug.Log("Jugador a prop de la instància (Trigger Enter)");
        }
    }

    // Es dispara si el jugador s'allunya de la bola sense agafar-la
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            Instance.instance.isColliding = false; // Avisem al script de l'Emma
            Debug.Log("Jugador s'ha allunyat (Trigger Exit)");
        }
    }

}