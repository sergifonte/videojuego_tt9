using UnityEngine;
using UnityEngine.SceneManagement;

public class UiTutorial : MonoBehaviour
{
    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private GameObject uiJocNivell;

    public void OpenConfiguration()//lincat amb el botó de la rodeta
    {
        if (menuAjustes != null)
        {
            menuAjustes.SetActive(true);

            if (uiJocNivell != null) uiJocNivell.SetActive(false);
        }
    }

    public void CloseConfiguration()
    {
        if (menuAjustes != null)
        {
            menuAjustes.SetActive(false);

            if (uiJocNivell != null) uiJocNivell.SetActive(true);
        }
    }

    public void AbandonarPartida()//porta al main title
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ConfigurarResolucioAlta()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed); //poso windowed perquè si em crashea el joc pugui minimitar-lo o tancar-lo
        Debug.Log("Forçat a 1920x1080 en mode Finestra");
    }

    public void ConfigurarResolucioMitjana()
    {
        Screen.SetResolution(1600, 900, FullScreenMode.Windowed);
        Debug.Log("Forçat a 1600x900 en mode Finestra");
    }

    public void ConfigurarResolucioBaixa()
    {
        Screen.SetResolution(1366, 768, FullScreenMode.Windowed);
        Debug.Log("Forçat a 1366x768 en mode Finestra");
    }
}