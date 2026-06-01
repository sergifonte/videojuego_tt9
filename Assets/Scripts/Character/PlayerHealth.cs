using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float _maxHealth = 100f;
    public float _currentHealth;

    [SerializeField] private HealthBar _healthBar;

    public Transform _spawnPoint;

    private CharacterController _characterController;

    void Start()
    {
        _currentHealth = _maxHealth;
        _characterController = GetComponent<CharacterController>();

        if (_healthBar != null)
        {
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
        }
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);

        if (_healthBar != null)
        {
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
        }

        if (_currentHealth <= 0)
        {
            RespawnPerMort();
        }
    }

    private void RespawnPerMort()
    {
        Debug.Log("El jugador s'ha quedat sense espelma! Respawnejant...");

        if (_spawnPoint != null)
        {
            //Desactivem el controller per evitar bugs
            if (_characterController != null) _characterController.enabled = false;

            //Teletransportem el personatge al spawn inicial
            transform.position = _spawnPoint.position;
            transform.rotation = _spawnPoint.rotation;

            //Tornem a activar el controller per poder jugar
            if (_characterController != null) _characterController.enabled = true;
        }
        else
        {
            Debug.LogError("ALERTA: No has assignat el Spawn Point a l'inspector del PlayerHealth!");
        }

        //Li tornem a donar tota la vida i actualitzem la barra
        _currentHealth = _maxHealth;
        if (_healthBar != null)
        {
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
        }
    }
}