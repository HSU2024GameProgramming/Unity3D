using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        Debug.Log("Boss took damage. Current health: " + currentHealth);
    }

    void Die()
    {
        // 보스 사망 처리
        Debug.Log("Boss died.");
        Destroy(gameObject); // 또는 다른 사망 처리
    }
}
