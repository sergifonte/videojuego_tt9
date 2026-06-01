using UnityEngine;

public class Life : MonoBehaviour
{
    public float damageAmount = 0.1f; 
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("No s'ha trobat el script PlayerHealth en aquest objecte!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("fireBall") && playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}