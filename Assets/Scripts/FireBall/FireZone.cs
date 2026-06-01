using UnityEngine;

public class FireZone : MonoBehaviour
{
    public FireEnemy fireBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            if (fireBall != null)
            {
                fireBall.activeChasing = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            if (fireBall != null)
            {
                fireBall.activeChasing = false;
            }
        }
    }
}