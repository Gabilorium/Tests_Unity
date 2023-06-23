using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jugador : MonoBehaviour
{
    private float maxLife = 20f;
    public float life { get; private set; }
    public float contactDamage = 3.5f;
    private float damageCooldown = 0.5f;
    private float damageTimer = 0.0f;

    private Enemy enemy;
    void Awake()
    {
        life = maxLife;
    }

    void Update()
    {
        Debug.Log("Cooldown: " + damageTimer);
        Debug.Log("El enemigo tiene: " + enemy.life + " de vida");
        Debug.Log("El jugador tiene: " + life + " de vida");
        if (damageCooldown > 0)
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            /*player*/TakeDamage(enemy.contactDamage);
            /*enemy*/enemy.TakeDamage(contactDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        if (damageTimer <= 0)
        {
            life -= damage;

            if (life <= 0)
            {
                // Eliminar el enemigo si la vida llega a 0
                Destroy(gameObject);
            }

            damageTimer = damageCooldown;
        }
        
    }
}
