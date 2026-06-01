using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //comprovem si el que ha creuat el checkpoint és el jugador
        if (other.CompareTag("Player"))
        {
            Spawner spawner = FindObjectOfType<Spawner>();

            if (spawner != null)
            {
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