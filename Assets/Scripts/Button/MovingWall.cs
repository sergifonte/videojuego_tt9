using UnityEngine;
[RequireComponent(typeof(AudioSource))] 
public class MovingWall : MonoBehaviour
{
    [SerializeField] private ReusableButton botoDeLaPantalla;
    [SerializeField] private float distanciaX = 4f;
    [SerializeField] private float velocitat = 3f;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip movingWallSound; 

    private Vector3 posicioInicial;
    private Vector3 posicioFinal;
    private AudioSource audioSource;
    private bool soReproduit = false; 

    void Start()
    {
        posicioInicial = transform.position;
        posicioFinal = posicioInicial + new Vector3(distanciaX, 0, 0);

        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (botoDeLaPantalla == null) return;

        Vector3 posicioObjectiu = botoDeLaPantalla.IsPressed ? posicioFinal : posicioInicial;

        if (botoDeLaPantalla.IsPressed && !soReproduit)
        {
            if (movingWallSound != null)
            {
                audioSource.PlayOneShot(movingWallSound);
            }
            soReproduit = true; 
        }

        transform.position = Vector3.MoveTowards(transform.position, posicioObjectiu, velocitat * Time.deltaTime);
    }
}