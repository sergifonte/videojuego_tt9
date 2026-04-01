using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthsprites;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthsprites.fillAmount = currentHealth / maxHealth;
    }

    void Update()
    {
        
    }
}
