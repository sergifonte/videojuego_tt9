using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuAjustes;

    public void ObrirMenuAjustes()
    {
        if (menuAjustes != null)
        {
            menuAjustes.SetActive(true);
        }
    }

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
