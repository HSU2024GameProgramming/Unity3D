using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // �Ѿ� �ӵ�
    public GameObject impactEffect; // �浹 �� ��Ÿ�� ������ ȿ��
    public int damageAmount = 10; // �������� �� ������

    void Update()
    {
        // �Ѿ� �̵�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹 �� ȿ�� ����
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        // �Ѿ��� ��ü�� �浹���� ��
        if (other.CompareTag("Boss")) // ������ �±װ� "Boss"�� ���
        {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damageAmount);
            }
        }

        // �Ѿ� ����
        Destroy(gameObject);
    }
}
