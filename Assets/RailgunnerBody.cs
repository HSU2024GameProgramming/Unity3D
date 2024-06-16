using UnityEngine;

public class RailgunnerBody : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform firePoint; // �Ѿ��� �߻�� ��ġ
    public float fireRate = 1f; // �߻� ���� (��)
    private float nextFireTime = 0f; // ���� �߻� ���� �ð�

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
