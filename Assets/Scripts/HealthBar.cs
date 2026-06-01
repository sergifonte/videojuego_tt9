using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthsprites; 

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        if (_healthsprites != null && maxHealth > 0)
        {
            _healthsprites.fillAmount = currentHealth / maxHealth;
        }
    }
}