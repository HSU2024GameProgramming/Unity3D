using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // �̱��� �ν��Ͻ�

    private int score = 0; // ���� ����

    // ������ ǥ���� UI ���� ������ �� �ֽ��ϴ�.
    // ���� ��� UI Text�� ����Ͽ� ������ ǥ���� �� �ֽ��ϴ�.

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
        Debug.Log("Score: " + score); // ���� ������ Ȯ���ϱ� ���� ����� �α�
        // ���⿡ UI ������Ʈ ���� �߰� ������ ���� �� �ֽ��ϴ�.
    }
}