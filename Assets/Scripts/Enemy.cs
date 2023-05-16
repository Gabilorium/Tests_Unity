using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    /*NavMeshAgent agente;
    public Movement _jugador;*/
    public float rangoDeAlerta;
    public float velocidad;
    public Transform jugador;
    public LayerMask capaDelJugador;

    // Start is called before the first frame update
    void Awake()
    {
        /*agente = GetComponent<NavMeshAgent>();
        _jugador= FindObjectOfType<Movement>();*/
    }

    // Update is called once per frame
    void Update()
    {
        //agente.SetDestination(_jugador.transform.position);
        bool estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta) 
        {
            Vector3 direccionJugador = (jugador.position - transform.position).normalized;
            Quaternion rotacion = Quaternion.LookRotation(direccionJugador);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime * velocidad);
            transform.Translate(0, 0, velocidad * Time.deltaTime);
        }
    }
}

