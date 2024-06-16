using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // �Ѿ� �ӵ�
    public GameObject impactEffect; // �浹 �� ��Ÿ�� ������ ȿ��
    public int damage = 10; // �Ѿ��� �� ������

    void Update()
    {
        // �Ѿ� �̵�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet collided with: " + other.gameObject.name); // �浹�� ������Ʈ �̸� ���

        // �浹 �� ȿ�� ����
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        // �浹�� ������Ʈ�� �������� ����
        BossHealth bossHealth = other.GetComponent<BossHealth>();
        if (bossHealth != null)
        {
            bossHealth.TakeDamage(damage);
        }

        // �Ѿ� ����
        Destroy(gameObject);
    }
}


