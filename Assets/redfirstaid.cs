using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redfirstaid : MonoBehaviour
{
    public int healAmount = 20; // ȸ����
    public GameObject pickupEffect; // ������ ����� �� ���� ȿ�� ������

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
}