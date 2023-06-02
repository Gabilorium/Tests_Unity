using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float bulletDamage = 1.0f;
    //private float timeDestroy = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            // Disminuir la salud del enemigo
            enemy.TakeDamage(bulletDamage);
            Debug.Log("El enemigo tiene: " + enemy.life + " de vida");
            // Destruir la bala
        }

        if (!collision.gameObject.CompareTag("Jugador"))
        {
            Destroy(gameObject);
        }

        

    }
}