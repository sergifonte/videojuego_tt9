using UnityEngine;

public class Landing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Col·lisió jugador-plataforma"); 
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador enganxat");
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             Debug.Log("Jugador enganxat");
            other.transform.SetParent(null);
        }
    }
}
