using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jugador : MonoBehaviour
{
    private int maxLife = 20;
    private float life;
    public float contactDamage = 3f;
    private float damageCooldown = 2f;

    void start()
    {
        life = maxLife;
    }

    void Update()
    {
        if (damageData.timer > 0)
        {
            damageData.timer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Functions.TakeDamage(damageData, enemy.contactDamage, damageCooldown);
            enemy.Functions.TakeDamage(contactDamage, damageCooldown);
        }
    }
}