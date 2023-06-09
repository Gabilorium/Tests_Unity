using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float velocidad = 20f;
    private float nextFire = 0.5F;
    public GameObject projectile;
    public float fireDelta = 0.2F;
    public GameObject newProjectile;
    private float myTime = 0.0F;
    private float timeDestroy = 2f;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            rb.velocity = (transform.forward * velocidad ) ;

            // Destruir la bala después de 2 segundos
            Destroy(newProjectile, timeDestroy);

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }
}
