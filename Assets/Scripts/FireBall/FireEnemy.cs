using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float rotationSpeed = 5f;

    public bool activeChasing = false;

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        if (player != null)
        {
            //Efecte flotant
            float floatOffset = Mathf.Sin(Time.time * 2f) * 0.5f;

            if (activeChasing)
            {
                //Movimentcap al jugador
                Vector3 targetPosition = new Vector3(player.position.x, startY, player.position.z);
                Vector3 direction = (targetPosition - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;

                //Rotació cap al jugador
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }

                //Posició
                transform.position = new Vector3(transform.position.x, startY + floatOffset, transform.position.z);
            }
            else
            {
                //Si està sol sense el jugador, només flota en el seu lloc original sense perseguir
                transform.position = new Vector3(transform.position.x, startY + floatOffset, transform.position.z);
            }
        }
    }
}
