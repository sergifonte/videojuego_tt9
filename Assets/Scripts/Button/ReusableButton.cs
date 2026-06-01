using UnityEngine;
public class ReusableButton : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource; 

    public bool IsPressed { get; private set; } = false;

    [Header("Audio Settings")]
    public AudioClip buttonPressSound; 

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !IsPressed)
        {
            //comprova script de l'emma amb l'instancia
            if (Instance.instance != null && Instance.instance.index == 0)
            {
                ActivarBoto();
            }
            else
            {
                Debug.Log("L'espelma ha saltat a sobre, però és petita");
            }
        }
    }

    private void ActivarBoto()
    {
        IsPressed = true;

        if (animator != null)
        {
            animator.SetTrigger("Press");
        }

        if (buttonPressSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonPressSound);
        }

        Debug.Log("Botó activat i so reproduït");
    }
}