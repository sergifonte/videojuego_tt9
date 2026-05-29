using UnityEngine;

public class ReusableButton : MonoBehaviour
{
    private Animator animator;

    // Propietat pública per indicar a la porta o a la UI si ja s'ha premut
    public bool IsPressed { get; private set; } = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si és el jugador i el botó encara no s'ha aixafat...
        if (other.CompareTag("Player") && !IsPressed)
        {
            // COMPROVACIÓ DE MIDA: Només si l'Emma diu que som grans (index == 0)
            if (Instance.instance != null && Instance.instance.index == 0)
            {
                ActivarBoto();
            }
            else
            {
                Debug.Log("L'espelma ha saltat a sobre, però és petita. Necessita ser gran per fer pes!");
            }
        }
    }

    private void ActivarBoto()
    {
        IsPressed = true;

        if (animator != null)
        {
            animator.SetTrigger("Press"); // Dispara l'animació de baixar
        }

        Debug.Log("¡Botó activat automàticament pel pes de la mida gran!");
    }
}