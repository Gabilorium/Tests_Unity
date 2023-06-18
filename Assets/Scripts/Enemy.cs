using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float contactDamage = 5f;
    private float damageCooldown = 2f;
    private Functions.DamageData damageData;

    void Awake()
    {
        damageData = new Functions.DamageData();
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
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            Functions.TakeDamage(damageData, jugador.contactDamage, damageCooldown);
            jugador.Functions.TakeDamage(contactDamage, damageCooldown);
        }
    }

}