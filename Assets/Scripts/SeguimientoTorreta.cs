using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoTorreta : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 100f;
    public float fireRate = 2f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private float nextFireTime;
    public float velocidad = 20f;
    private float timeDestroy = 2f;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Time.time >= nextFireTime && IsInFieldOfView())
            {
                Fire();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bullet.transform.forward * velocidad;
        }
        Destroy(bullet, timeDestroy);
    }

    bool IsInFieldOfView()
    {
        Vector3 directionToTarget = target.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (angle < 90f)
        {
            return true;
        }

        return false;
    }
}
