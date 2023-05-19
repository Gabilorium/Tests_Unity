using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float velocidad = 20f;
    public GameObject prefabBala;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Puedes ajustar el nombre del botón según tus necesidades
        {
            Disparar();
        }
        
        if (Input.GetButtonDown("Fire2")) // Puedes ajustar el nombre del botón según tus necesidades
        {
            Disparar();
        }
    }
    void Disparar()
    {
        GameObject bala = Instantiate(prefabBala, transform.position, transform.rotation);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocidad;
    }

}
