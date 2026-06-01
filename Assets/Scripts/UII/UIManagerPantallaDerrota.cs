using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerPantallaDerrota : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip defeatSound; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false; 

        if (defeatSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(defeatSound);
        }
    }

    public void ChangeToPantallaPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(3);
    }
}