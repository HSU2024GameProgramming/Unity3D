using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // 총알 속도
    public GameObject impactEffect; // 충돌 시 나타날 프리팹 효과
    public int damage = 10; // 총알이 줄 데미지

    void Update()
    {
        // 총알 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet collided with: " + other.gameObject.name); // 충돌한 오브젝트 이름 출력

        // 충돌 시 효과 생성
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        // 충돌한 오브젝트에 데미지를 입힘
        BossHealth bossHealth = other.GetComponent<BossHealth>();
        if (bossHealth != null)
        {
            bossHealth.TakeDamage(damage);
        }

        // 총알 삭제
        Destroy(gameObject);
    }
}


