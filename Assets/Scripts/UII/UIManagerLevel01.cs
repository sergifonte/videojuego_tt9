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

    public void ConfigurarResolucioAlta()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed); //poso windowed perque si em crashea el joc pugui minimitar-lo o tancar-lo
        Debug.Log("1920x1080");
    }

    public void ConfigurarResolucioMitjana()
    {
        Screen.SetResolution(1600, 900, FullScreenMode.Windowed);
        Debug.Log("1600x900");
    }

    public void ConfigurarResolucioBaixa()
    {
        Screen.SetResolution(1366, 768, FullScreenMode.Windowed);
        Debug.Log("1366x768");
    }
}
