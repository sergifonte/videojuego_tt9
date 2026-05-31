using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private ReusableButton botoDeLaPantalla;

    [SerializeField] private float distanciaX = 4f;

    [SerializeField] private float velocitat = 3f;

    private Vector3 posicioInicial;
    private Vector3 posicioFinal;

    void Start()
    {
        posicioInicial = transform.position;

        posicioFinal = posicioInicial + new Vector3(distanciaX, 0, 0);
    }

    void Update()
    {
        if (botoDeLaPantalla == null) return;

        Vector3 posicioObjectiu = botoDeLaPantalla.IsPressed ? posicioFinal : posicioInicial;

        transform.position = Vector3.MoveTowards(transform.position, posicioObjectiu, velocitat * Time.deltaTime);
    }
}