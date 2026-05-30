using UnityEngine;

public class FireZone : MonoBehaviour
{
    public FireEnemy fireBall;

    private void OnTriggerEnter(Collider other)
    {
        //Si el que entra a la zona té el script de vida del jugador...
        if (other.GetComponent<PlayerHealth>() != null)
        {
            if (fireBall != null)
            {
                fireBall.activeChasing = true; //Activem la persecució
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Si el jugador surt de la zona...
        if (other.GetComponent<PlayerHealth>() != null)
        {
            if (fireBall != null)
            {
                fireBall.activeChasing = false; //Aturem la persecució
            }
        }
    }
}