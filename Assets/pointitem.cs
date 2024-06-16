using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointitem : MonoBehaviour
{
    public int scoreValue = 1; // ��� ����Ʈ ��
    public GameObject impactEffect; // �浹 �� ����Ʈ ȿ�� ������

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹�ߴ��� Ȯ��
        if (other.CompareTag("Player"))
        {
            // ����Ʈ �߰�
            GameManager.Instance.AddScore(scoreValue);

            // ����Ʈ ȿ�� ����
            if (impactEffect != null)
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
            }

            // ������ ����
            Destroy(gameObject);
        }
    }
}