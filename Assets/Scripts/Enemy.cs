using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agente;
    public Jugador _jugador;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    private int maxLife = 5;
    public float life;
    public float enemyDamage = 5f;
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
    }

    public void TakeDamage(float damage)
    {
            life -= damage;

            if (life <= 0)
            {
                // Eliminar el enemigo si la vida llega a 0
                Destroy(gameObject);
            }
    }
}
