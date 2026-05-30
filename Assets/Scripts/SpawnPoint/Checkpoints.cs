using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprovem si el que ha creuat el checkpoint és el jugador
        if (other.CompareTag("Player"))
        {
            // Busquem el script Spawner que hi ha a la escena (el de la zona de mort)
            Spawner spawner = FindObjectOfType<Spawner>();

            if (spawner != null)
            {
                // Assignem directament la transformació (posició i rotació) d'aquest Checkpoint
                spawner.spawnPoint = this.transform;

                Debug.Log($"[Checkpoint] Nou punt de respawn guardat: {gameObject.name}");
            }
            else
            {
                Debug.LogWarning("No s'ha trobat cap script 'Spawner' a la escena!");
            }
        }
    }
}