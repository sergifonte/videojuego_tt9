using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            // moviment cap al jugador
            transform.position += direction * speed * Time.deltaTime;

            // efecte flotant
            float floatY = Mathf.Sin(Time.time * 2f) * 0.5f;
            transform.position = new Vector3(transform.position.x, floatY, transform.position.z);
        }
    }
}