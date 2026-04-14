using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManagerTitle : MonoBehaviour
{
    public void ChangeToLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void ChangeToAjustes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ChangeToCreditos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Debug.Log("Exiting the Game...");
        Application.Quit();
    }
    

}
