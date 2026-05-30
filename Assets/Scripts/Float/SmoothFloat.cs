using UnityEngine;

public class SmoothFloat : MonoBehaviour
{
    [Header("Configuració del moviment")]
    public float floatSpeed = 2f;
    public float floatHeight = 0.5f;

    // CASSELLA NOVA: Per triar cap a on comença a moure's
    [Tooltip("Si està activat, començarà anant cap avall. Si està desactivat, començarà anant cap amunt.")]
    public bool comencarCapAbaix = false;

    [Header("Mida de la Zona de Detecció")]
    public Vector3 midaZona = new Vector3(1.5f, 1.5f, 1.5f);
    public Vector3 centreOffset = new Vector3(0f, 0.8f, 0f);

    private float startY;
    private Transform playerTransform;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // 1. Calculem l'ona de moviment bàsica (Sinus)
        float movimentOna = Mathf.Sin(Time.time * floatSpeed);

        // TRUC: Si l'usuari ha marcat la casella, invertim l'ona amb un signe menys (-) perquè comenci al revés
        if (comencarCapAbaix)
        {
            movimentOna = -movimentOna;
        }

        // Calculem la posició final de la plataforma
        float newY = startY + movimentOna * floatHeight;
        Vector3 nextPosition = new Vector3(transform.position.x, newY, transform.position.z);

        Vector3 moveDelta = nextPosition - transform.position;

        // 2. DETECCIÓ RECTANGULAR
        Vector3 boxCenter = transform.position + centreOffset;
        Collider[] collidersASobre = Physics.OverlapBox(boxCenter, midaZona / 2f, transform.rotation);

        bool jugadorASobre = false;
        CharacterController playerCC = null;

        foreach (Collider col in collidersASobre)
        {
            CharacterController cc = col.GetComponent<CharacterController>();
            if (cc != null)
            {
                playerTransform = col.transform;
                playerCC = cc;
                jugadorASobre = true;
                break;
            }
        }

        // 3. Apliquem el moviment a la plataforma
        transform.position = nextPosition;

        // 4. SINCRONIA DE MOVIMENT
        if (jugadorASobre && playerTransform != null && playerCC != null)
        {
            bool prementSalt = Input.GetKey(KeyCode.Space) || Input.GetButton("Jump");

            if (playerCC.isGrounded && !prementSalt)
            {
                playerCC.Move(moveDelta);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 boxCenter = transform.position + centreOffset;
        Gizmos.DrawWireCube(boxCenter, midaZona);
    }
}