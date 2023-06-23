using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaTorreta : MonoBehaviour
{
    public float bulletDamage = 1.0f;
    private float damageCooldown = 2f;
    private float damageTimer = 0.0f;
    //private float timeDestroy = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Jugador Jugador = collision.gameObject.GetComponent<Jugador>();

            // Disminuir la salud del enemigo
            Jugador.TakeDamage(bulletDamage);
            Debug.Log("El enemigo tiene:  de vida");
            // Destruir la bala
        }

        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        

    }
}