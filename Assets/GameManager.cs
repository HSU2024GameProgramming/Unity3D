using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글톤 인스턴스

    private int score = 0; // 현재 점수

    // 점수를 표시할 UI 등을 연결할 수 있습니다.
    // 예를 들어 UI Text를 사용하여 점수를 표시할 수 있습니다.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score); // 점수 증가를 확인하기 위한 디버그 로그
        // 여기에 UI 업데이트 등의 추가 로직을 넣을 수 있습니다.
    }
}