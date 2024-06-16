using System.Collections;
using UnityEngine;

public class RandomRespawner : MonoBehaviour
{
    [SerializeField] private GameObject rangeObject; // 범위를 지정할 오브젝트
    [SerializeField] private GameObject firstaid;    // 생성할 오브젝트 프리팹
    private BoxCollider rangeCollider;

    private void Awake()
    {
        if (rangeObject != null)
        {
            rangeCollider = rangeObject.GetComponent<BoxCollider>();
            if (rangeCollider == null)
            {
                Debug.LogError("The rangeObject does not have a BoxCollider component!");
            }
        }
        else
        {
            Debug.LogError("Range Object is not assigned!");
        }
    }

    Vector3 Return_RandomPosition()
    {
        if (rangeCollider == null)
        {
            return Vector3.zero;
        }

        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        float random_X = Random.Range((range_X / 2) * -1, range_X / 2);
        float random_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 randomPosition = new Vector3(random_X, 0f, random_Z);

        Vector3 respawnPosition = originPosition + randomPosition;
        return respawnPosition;
    }

    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (firstaid != null)
            {
                Instantiate(firstaid, Return_RandomPosition(), Quaternion.identity);
            }
            else
            {
                Debug.LogError("First Aid object is not assigned!");
            }
        }
    }
}
