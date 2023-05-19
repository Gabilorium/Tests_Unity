using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float velocidad = 20f;
    private float nextFire = 0.5F;
    public GameObject projectile;
    public float fireDelta = 0.2F;
    private GameObject newProjectile;
    private float myTime = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
   
    }
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            //projectile = Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * velocidad;
            // create code here that animates the newProjectile

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }

    /*void Disparar()
    {
        GameObject bala = Instantiate(projectile, transform.position, transform.rotation);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocidad;
    }*/
    
    /*
    // Update is called once per frame
    void Update()
    {
        //myTime = myTime + Time.deltaTime;

        /*if (Input.GetButton("Fire1") && myTime > nextFire) // Puedes ajustar el nombre del botón según tus necesidades
        {
            Disparar();
        }
        
        if (Input.GetButtonDown("Fire2")) // Puedes ajustar el nombre del botón según tus necesidades
        {
            Disparar();
        }
    }*/
}
