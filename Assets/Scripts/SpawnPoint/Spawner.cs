using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint; 

    private void OnTriggerEnter(Collider Ground) 
    {
        if (Ground.CompareTag("Player")) 
            //es comprova que el objecte que ha caigut al buit sigui el player
        {
            CharacterController Control_jugador = Ground.GetComponent<CharacterController>(); 

            if (Control_jugador != null) Control_jugador.enabled = false; 

            Ground.transform.position = spawnPoint.position;
            Ground.transform.rotation = spawnPoint.rotation;

            if (Control_jugador != null) Control_jugador.enabled = true; 

            Debug.Log("El jugador ha respawnejat correctament!"); 
        }
        else
        { 
            Debug.Log("PROBLEMA EN EL RESPAWN: L'objecte no és el Player");
        }
    }
}