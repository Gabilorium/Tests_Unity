using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agente;
    public Movement _jugador;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    private int maxVida = 5;
    public float vida;
    public Bala bala;
    // Start is called before the first frame update
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        _jugador= FindObjectOfType<Movement>();
        //bala = GetComponent<Bala>();
        vida = maxVida;
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

    public void TakeDamage()
    {
        vida = vida - bala.daño;

        if (vida <= 0)
        {
            // Eliminar el enemigo si la vida llega a 0
            Destroy(gameObject);
        }
    }
}
