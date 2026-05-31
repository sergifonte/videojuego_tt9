using UnityEngine;

public class CheckpointUI : MonoBehaviour
{
    [SerializeField] private GameObject mensajeCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mensajeCheckpoint != null)
            {
                mensajeCheckpoint.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mensajeCheckpoint != null)
            {
                mensajeCheckpoint.SetActive(false);
            }
        }
    }
}