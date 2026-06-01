using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerPantallaDerrota : MonoBehaviour
{//els index es troben al aparta build profiles

    public void ChangeToPantallaPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(3);
    }


}
