using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerPantallaVictoria : MonoBehaviour
{
     [SerializeField] private string tagJugador = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            LoadSceneVictoria();
        }
    }

    public void LoadSceneVictoria()
    {
        SceneManager.LoadScene(5);
    }
}