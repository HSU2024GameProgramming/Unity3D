using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // 총알 속도
    public GameObject impactEffect; // 충돌 시 나타날 프리팹 효과
    public int damageAmount = 10; // 보스에게 줄 데미지

    void Update()
    {
        // 총알 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌 시 효과 생성
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        // 총알이 물체와 충돌했을 때
        if (other.CompareTag("Boss")) // 보스의 태그가 "Boss"인 경우
        {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damageAmount);
            }
        }

        // 총알 삭제
        Destroy(gameObject);
    }
}
