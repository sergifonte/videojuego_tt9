using UnityEngine;

public class Life : MonoBehaviour
{
    /*SCRIPT PER LES BOLES DE FOC QUE LI BAIXEN LA VIDA AL JUGADOR
      Detecta tant per col·lisió sòlida com per Trigger (transparent)*/

    public float damageAmount = 1.0f;
    private bool isColliding = false;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update() //Això para el joc si el jugador es mor
    {
        if (playerHealth._currentHealth <= 0)
        {
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fireBall"))
        {
            playerHealth.TakeDamage(damageAmount);
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("fireBall"))
        {
            isColliding = false;
        }
    }

    //Script anterior
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("fireBall"))
    //    {
    //        playerHealth.TakeDamage(damageAmount);
    //        isColliding = true;
    //    }
    //}

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject.CompareTag("fireBall"))
    //    {
    //        isColliding = false;
    //    }
    //}
}
