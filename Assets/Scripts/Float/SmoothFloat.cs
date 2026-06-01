using UnityEngine;

public class SmoothFloat : MonoBehaviour
{
    [Header("Configuració del moviment")]
    public float floatSpeed = 2f;
    public float floatHeight = 0.5f;

    [Tooltip("Si està activat, començarà anant cap avall. Si està desactivat, començarà anant cap amunt.")]
    public bool comencarCapAbaix = false;

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float movimentOna = Mathf.Sin(Time.time * floatSpeed);

        if (comencarCapAbaix)
        {
            movimentOna = -movimentOna;
        }

        float newY = startY + movimentOna * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}