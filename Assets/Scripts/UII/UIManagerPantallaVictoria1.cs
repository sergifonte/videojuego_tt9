using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class UIManagerPantallaVictoria1 : MonoBehaviour
{
    [SerializeField] private VideoPlayer meuVideoPlayer;

    void Start()
    {
        if (meuVideoPlayer != null)
        {
            meuVideoPlayer.loopPointReached += (vp) => UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }//mode loop -> se'n va a l'escena del MENÚ
    }
}