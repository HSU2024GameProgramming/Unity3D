using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject damageEffect; // 데미지 받을 때 나올 효과 프리팹

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // 데미지 효과 생성
        if (damageEffect != null)
        {
            Instantiate(damageEffect, transform.position, transform.rotation);
        }

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

