using UnityEngine;
using UnityEngine.SceneManagement;

public class UiTutorial : MonoBehaviour
{
    [SerializeField] private GameObject menuAjustes;

    [SerializeField] private GameObject uiJocNivell;

    public void ObrirMenuAjustes()
    {
        if (menuAjustes != null)
        {
            menuAjustes.SetActive(true);

            if (uiJocNivell != null) uiJocNivell.SetActive(false);
        }
    }

    public void TancarMenuAjustes()
    {
        if (menuAjustes != null)
        {
            menuAjustes.SetActive(false);

            if (uiJocNivell != null) uiJocNivell.SetActive(true);
        }
    }

    public void AbandonarPartida()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}