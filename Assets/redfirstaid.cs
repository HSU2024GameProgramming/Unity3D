using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redfirstaid : MonoBehaviour
{
    public int healAmount = 20; // 회복량
    public GameObject pickupEffect; // 아이템 사라질 때 나올 효과 프리팹

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌했는지 확인
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // 플레이어의 체력 회복
            playerHealth.Heal(healAmount);

            // 아이템 사라질 때 효과 생성
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }

            // 아이템 삭제
            Destroy(gameObject);
        }
    }
}