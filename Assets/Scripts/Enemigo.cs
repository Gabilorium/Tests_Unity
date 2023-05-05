using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float rangoDeAlerta;
    public float velocidad;
    public Transform jugador;
    public LayerMask capaDelJugador;

    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
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