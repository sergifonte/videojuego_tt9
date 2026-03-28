using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint; //llegim el GameObject buit del SpawnPoint al inspector

    private void OnTriggerEnter(Collider Ground) //el gameObject té el trigger activat perquè ho llegeixi el codi
    {
        if (Ground.CompareTag("Player")) //el tag està enllaçat a la part de dalt del inspector al GameObject "Character"
            //comprovem que el objecte que ha caigut al buit sigui el player
        {
            CharacterController Control_jugador = Ground.GetComponent<CharacterController>(); //llegim el character controler que el Character té
            //li he assignat el nom de la variable "Control_jugador"

            //perquè el usuari eviti de moure el player quan aquest ja ha tocat el buit (així evitem bugs raros del futur)
            if (Control_jugador != null) Control_jugador.enabled = false; //desactivem els controls perquè el usuari NO el pugui moure

            //respawnegem el jugador en la posició i rotació tal i com està el SpawnPoint
            Ground.transform.position = spawnPoint.position;
            Ground.transform.rotation = spawnPoint.rotation;

            if (Control_jugador != null) Control_jugador.enabled = true; //tornem a activar els permisos perquè el usuari pugui jugar

            Debug.Log("El jugador ha respawnejat correctament!"); //enviem un debug a la pantalla per comprovar que tot funcioni correctament
        }
        else
        { //en cas de que hi hagi algun problema sortirà això:
          // Això sortirà si cau qualsevol altra objecte (un cub, una bala, etc.)
            Debug.Log("PROBLEMA EN EL RESPAWN: L'objecte no és el Player");
        }
    }
}