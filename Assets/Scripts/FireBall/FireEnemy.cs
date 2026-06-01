using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class FireEnemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float rotationSpeed = 5f;

    public bool activeChasing = false;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip fireLoopSound; 

    private Vector3 positionSenseFlotar;
    private AudioSource audioSource;
    private bool soReproduintse = false;

    void Start()
    {
        positionSenseFlotar = transform.position;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fireLoopSound;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (player != null)
        {
            float floatOffset = Mathf.Sin(Time.time * 2f) * 0.5f;

            if (activeChasing)
            {
                Vector3 direction = (player.position - positionSenseFlotar).normalized;
                positionSenseFlotar += direction * speed * Time.deltaTime;

                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }

                if (!soReproduintse && fireLoopSound != null)
                {
                    audioSource.Play();
                    soReproduintse = true;
                }
            }
            else
            {
                if (soReproduintse)
                {
                    audioSource.Stop();
                    soReproduintse = false;
                }
            }

            transform.position = new Vector3(
                positionSenseFlotar.x,
                positionSenseFlotar.y + floatOffset,
                positionSenseFlotar.z
            );
        }
    }
}