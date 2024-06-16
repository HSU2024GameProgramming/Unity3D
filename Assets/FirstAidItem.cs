using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidItem : MonoBehaviour
{
    public int healAmount = 20; // ȸ����
    public GameObject pickupEffect; // ������ ����� �� ���� ȿ�� ������
    public GameObject spawnEffect; // ������ ������ �� ���� ȿ�� ������
    public float destroyTime = 10f; // �ڵ����� ����� �ð� (��)

    private Rigidbody rb;

    private void Start()
    {
        // ������ ������ �� ȿ�� ����
        if (spawnEffect != null)
        {
            Instantiate(spawnEffect, transform.position, transform.rotation);
        }

        // ���� �ð��� ���� �� ������ �ڵ� ����
        Destroy(gameObject, destroyTime);

        // Rigidbody ������Ʈ ����
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹�ߴ��� Ȯ��
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // �÷��̾��� ü�� ȸ��
            playerHealth.Heal(healAmount);

            // ������ ����� �� ȿ�� ����
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }

            // ������ ����
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        // �ٴڰ� �浹���� ��
        if (collision.gameObject.CompareTag("Plane"))
        {
            // Rigidbody�� �ӵ��� 0���� �����Ͽ� ���߰� �մϴ�.
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
