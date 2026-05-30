using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Tooltip("Punt exacte on apareixerà el jugador. Si es deixa buit, es farà servir la posició del propi Checkpoint.")]
    public Transform puntDeRespawnCustom;

    private void OnTriggerEnter(Collider other)
    {
        // Comprovem si el que ha creuat el checkpoint és el jugador
        if (other.CompareTag("Player"))
        {
            // Busquem el script Spawner que hi ha a la escena (el de la teva zona de mort)
            Spawner spawner = FindObjectOfType<Spawner>();

            if (spawner != null)
            {
                // Si hem assignat un punt custom, fem servir aquell. Si no, la posició d'aquest GameObject.
                Transform nouPunt = puntDeRespawnCustom != null ? puntDeRespawnCustom : this.transform;

                // Actualitzem el spawnPoint del teu script original
                spawner.spawnPoint = nouPunt;

                Debug.Log($"[Checkpoint] Nou punt de respawn guardat: {gameObject.name}");

                // Opcional: Desactivar el collider perquè no es torni a activar si el jugador hi passa de nou
                // GetComponent<Collider>().enabled = false;
            }
            else
            {
                Debug.LogWarning("No s'ha trobat cap script 'Spawner' a la escena!");
            }
        }
    }
}