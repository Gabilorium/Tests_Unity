using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agente;
    private float maxLife = 5f;
    public float life { get; private set; }
    public float contactDamage = 2f;
    private float damageCooldown = 0.5f;
    private float damageTimer = 0.0f;
    private float rangoDeAlerta = 10f;
    public LayerMask capaDelJugador;
    private Jugador player;

    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        life = maxLife;

    }

    void Update()
    {
        bool estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta) 
        {
            agente.SetDestination(player.transform.position);
        }
        if (damageCooldown > 0)
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            TakeDamage(jugador.contactDamage);
            jugador.TakeDamage(contactDamage);
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