using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SummonerEnemy : MonoBehaviour
{
    NavMeshAgent agente;
    public Jugador _jugador;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    private int maxLife = 5;
    public float life;
    public float contactDamage = 5f;
    private float spawnCooldown = 2f;
    private float SpawnTimer = 0.0f;
    private float damageCooldown = 3f;
    private float damageTimer = 0.0f;
    // Start is called before the first frame update
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        _jugador= FindObjectOfType<Jugador>();
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        bool estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta) 
        {
            agente.SetDestination(_jugador.transform.position);
        }

        /*if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Jugador player = collision.gameObject.GetComponent<Jugador>();
            // Disminuir la salud del enemigo
            player.TakeDamage(contactDamage);
            Debug.Log("El enemigo tiene: " + player.life + " de vida");
            TakeDamage(player.contactDamage);
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

