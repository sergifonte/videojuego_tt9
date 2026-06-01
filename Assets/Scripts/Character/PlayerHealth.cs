using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(9);
    }
}