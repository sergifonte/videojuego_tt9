using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Arrossega aquí el GameObject del teu menú d'ajustes des de l'Inspector
    [SerializeField] private GameObject menuAjustes;

    // Aquesta funció s'executarà en fer clic al botó d'obrir
    public void ObrirMenuAjustes()
    {
        if (menuAjustes != null)
        {
            menuAjustes.SetActive(true);
        }
    }

    // Opcional: Aquesta funció la pots assignar a un botó de "Tancar" (X) dins del menú
    public void TancarMenuAjustes()
    {
        if (menuAjustes != null)
        {
            menuAjustes.SetActive(false);
        }
    }

    public void AbandonarPartida()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
