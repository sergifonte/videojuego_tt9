using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSceneChanger : MonoBehaviour
{
    [SerializeField] private VideoPlayer meuVideoPlayer;

    void Start()
    {
        if (meuVideoPlayer != null)
        {
            meuVideoPlayer.loopPointReached += (vp) => UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }//mode loop -> se'n va a l'escena del nivell 1
    }
}