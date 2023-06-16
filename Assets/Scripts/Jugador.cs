using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private int maxLife = 20;
    public float life; 
    public float contactDamage = 3f;
    private float damageCooldown = 0.5f;
    private float damageTimer = 0.0f;
    public bool DashActivo = false;
    void Start()
    {
        //anim = GetComponent<Animator>();
        life = maxLife;
    }

    void Update()
    {
        if (damageTimer >= 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            // Disminuir la salud del enemigo
            enemy.TakeDamage(contactDamage);
            Debug.Log("El enemigo tiene: " + enemy.life + " de vida");
            TakeDamage(enemy.enemyDamage);
            Debug.Log("El jugador tiene: " + life + " de vida");
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