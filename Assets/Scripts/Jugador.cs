using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private int maxLife = 20;
    public float life { get; private set; }
    public float contactDamage = 3f;
    private float damageCooldown = 0.5f;
    private float damageTimer = 0.0f;
    private Enemy enemy;
    void Start()
    {
        life = maxLife;
        enemy = GetComponent<Enemy>();
    }
    
    void Update()
    {
        Debug.Log("Cooldown: " + damageTimer);
        Debug.Log("El jugador tiene: " + life + " de vida");
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    /*void FixedUpdate()
    {

    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            enemy = collision.gameObject.GetComponent<Enemy>();
            // Disminuir la salud del enemigo
            Function.TakeDamage(enemy, damage, damageCooldown, ref timer, ref life);
            TakeDamage(player.contactDamage, ref player.damageTimer, ref player.life);
            
        }
        
    }

    public void TakeDamage(float damage, ref float timer, ref float life)
    {
        Function.TakeDamage(gameObject, damage, damageCooldown, ref timer, ref life);
    }
}