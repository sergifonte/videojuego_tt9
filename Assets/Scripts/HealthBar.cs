using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthsprites; // Arrossega aquí la imatge amb el "Image Type: Filled"

    // Netegem els paràmetres, ara el mètode només fa cas al que li envien
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        if (_healthsprites != null && maxHealth > 0)
        {
            _healthsprites.fillAmount = currentHealth / maxHealth;
        }
    }
}