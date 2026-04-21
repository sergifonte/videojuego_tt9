using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprovem si el que ha entrat és el jugador
        if (other.CompareTag("Player"))
        {
            // Fem que el jugador sigui fill de la plataforma
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // En sortir, el jugador deixa de ser fill
            other.transform.SetParent(null);
        }
    }
}
