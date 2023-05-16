using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject bulletPrefab;

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
    
}