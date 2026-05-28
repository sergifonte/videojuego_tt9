using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSceneChanger : MonoBehaviour
{
    [SerializeField] private VideoPlayer meuVideoPlayer;

    void Start()
    {
        // Quan el vídeo arribi al final, executarà directament el canvi d'escena
        if (meuVideoPlayer != null)
        {
            meuVideoPlayer.loopPointReached += (vp) => UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}