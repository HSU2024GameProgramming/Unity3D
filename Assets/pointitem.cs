using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointitem : MonoBehaviour
{
    public int scoreValue = 1; // 얻는 포인트 값
    public GameObject impactEffect; // 충돌 시 임팩트 효과 프리팹

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌했는지 확인
        if (other.CompareTag("Player"))
        {
            // 포인트 추가
            GameManager.Instance.AddScore(scoreValue);

            // 임팩트 효과 생성
            if (impactEffect != null)
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
            }

            // 아이템 삭제
            Destroy(gameObject);
        }
    }
}