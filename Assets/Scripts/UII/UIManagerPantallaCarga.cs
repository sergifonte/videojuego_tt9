using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class UIManagerPantallaCarga : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPantallaCarga;

    void Start()
    {
        if (videoPantallaCarga != null)
        {
            // Mode loop -> se'n va a l'escena del TUTORIAL (Índex 1)
            videoPantallaCarga.loopPointReached += (vp) => SceneManager.LoadScene(1);
        }
    }
}