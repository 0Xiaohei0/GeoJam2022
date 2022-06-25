using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float maxHealth;
    public HealthBar healthBar;


    [SerializeField] private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void takeDamage(float damage)
    {
        if (!healthBar.gameObject.activeInHierarchy)
        {
            healthBar.gameObject.SetActive(true);
        }
        currentHealth -= damage;
        healthBar.UpdateHealth((float)currentHealth / maxHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}