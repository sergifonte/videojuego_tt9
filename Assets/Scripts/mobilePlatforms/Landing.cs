using UnityEngine;

public class Landing : MonoBehaviour
{
    // Aquest mètode és especial per a CharacterController
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("MovingPlatform"))
        {
            // Ens fem fills de la plataforma que hem colpejat
            transform.SetParent(hit.transform);
        }
        else
        {
            // Si el que trepitgem no és la plataforma, ens desenganxem
            transform.SetParent(null);
        }
    }
}