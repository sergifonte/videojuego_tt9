using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float rotationSpeed = 5f;

    public bool activeChasing = false;

    // Farem servir una posició interna virtual per moure el "cos" de la bola de foc
    private Vector3 positionSenseFlotar;

    void Start()
    {
        // Inicialitzem la nostra posició virtual on està la bola de foc al començar
        positionSenseFlotar = transform.position;
    }

    void Update()
    {
        if (player != null)
        {
            // 1. Efecte flotant bàsic (Ona sinus fixa)
            float floatOffset = Mathf.Sin(Time.time * 2f) * 0.5f;

            if (activeChasing)
            {
                // 2. MOVIMENT 3D SENSE INTERFERÈNCIES
                // Calculem la direcció des de la nostra posició virtual cap al jugador
                Vector3 direction = (player.position - positionSenseFlotar).normalized;

                // Movem la posició virtual (aquí no hi ha sinus, és un moviment net i lineal)
                positionSenseFlotar += direction * speed * Time.deltaTime;

                // 3. ROTACIÓ EN 3D
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }

            // 4. APLICACIÓ FINAL AL TRANSFORM
            // Ajuntem la posició real de moviment (X, Y, Z) i li sumem el sinus NOMÉS a l'eix Y visual.
            transform.position = new Vector3(
                positionSenseFlotar.x,
                positionSenseFlotar.y + floatOffset,
                positionSenseFlotar.z
            );
        }
    }
}