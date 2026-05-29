using UnityEngine;

public class ReusableButton : MonoBehaviour
{
    private Animator animator;
    // Propietat pública per indicar a la porta o a la UI si esta clicat
    public bool IsPressed { get; private set; } = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //condició amb tag Player al jugador i si el botó està premut
        if (other.CompareTag("Player") && !IsPressed)
        {
            // comprova mida del script de l'emma amb l'instancia
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

        Debug.Log("Botó activat");
    }
}