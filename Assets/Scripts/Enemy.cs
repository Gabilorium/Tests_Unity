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

    // Start is called before the first frame update
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        _jugador= FindObjectOfType<Movement>();
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
}

