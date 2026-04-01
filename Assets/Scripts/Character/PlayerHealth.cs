using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    private float _currentHealth;

    [SerializeField] private HealthBar _healthBar;

    void Start()
    {
        _currentHealth = _maxHealth;

        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
    }

   //(missatge Xènia PER EMMA):
   //aquí hauria d'anar la funció que li baixés els PS al jugador ;) tècnicament tant el script com la healthbar estan ben lincats
   //entenc que per veure visualment la barra baixar has de jugar amb l'opció de fill amount, es troba a: HEALTHBAR -> canvas -> backround -> fill
   //dins del fill a l'inspector trobaras la secció IMAGE i allà tens aquesta opció de fill amount que va dels valors 0 al 1
   //si necessites res avisa'm
   
}
