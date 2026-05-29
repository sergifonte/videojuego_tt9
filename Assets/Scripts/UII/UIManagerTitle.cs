using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManagerTitle : MonoBehaviour
{//els index es troben al aparta build profiles
    public void ChangeToPantallaCarga()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(8);
    }
    public void ChangeToAjustes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }

    public void ChangeToCreditos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }
    public void Exit()
    {
        Debug.Log("Exiting the Game...");
        Application.Quit();
    }
    

}
