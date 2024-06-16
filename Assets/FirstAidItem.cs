using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidItem : MonoBehaviour
{
    public int healAmount = 20; // 회복량
    public GameObject pickupEffect; // 아이템 사라질 때 나올 효과 프리팹
    public GameObject spawnEffect; // 아이템 생성될 때 나올 효과 프리팹
    public float destroyTime = 10f; // 자동으로 사라질 시간 (초)

    private Rigidbody rb;

    private void Start()
    {
        // 아이템 생성될 때 효과 생성
        if (spawnEffect != null)
        {
            Instantiate(spawnEffect, transform.position, transform.rotation);
        }

        // 일정 시간이 지난 후 아이템 자동 삭제
        Destroy(gameObject, destroyTime);

        // Rigidbody 컴포넌트 참조
        rb = GetComponent<Rigidbody>();
    }

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        // 바닥과 충돌했을 때
        if (collision.gameObject.CompareTag("Plane"))
        {
            // Rigidbody의 속도를 0으로 설정하여 멈추게 합니다.
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
