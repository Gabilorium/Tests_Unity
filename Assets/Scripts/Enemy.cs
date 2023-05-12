using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agente;
    public Movement _jugador;

    // Start is called before the first frame update
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        _jugador= FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //agente.SetDestination(_jugador.transform.position);
    }
}

