using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private new CapsuleCollider capsuleCollider;
    private CharacterController characterController;    
    private Animator anim;
    public new Transform camera;
    public float hor,ver;
    public float speed = 4f; 
    public float gravity = -9.8f;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.transform.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //capsuleCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0;
        //movementSpeed = 0;
        if (hor != 0.0f || ver != 0.0f){
            //para el salto transfrom.up
            
            //capsuleCollider.MovePosition(transform.position + dir * speed * Time.deltaTime);

            //Mover para adelante o atras
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();
            //Mover para la derecha o izquierda
            Vector3 right = camera.right;
            right.y = 0; 
            right.Normalize();
            //Digo en quqe dirección va a ir
            Vector3 dir = forward * ver + right * hor;

            //Cambiar velocidad de movimiento (acelerar o frenar)
            movementSpeed = Mathf.Clamp01(dir.magnitude);
            dir.Normalize();
            //Calcular el movimiento segín la dirección, la velocidad prefijada, 
            //la aceleración y los segundos que se apretó
            movement = dir * speed * movementSpeed * Time.deltaTime;

            //Mover el personaje (Solo la camara)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);


        }
            movement.y += gravity * Time.deltaTime;
            characterController.Move(movement);
            anim.SetFloat("Speed", movementSpeed); 

        /*while (movement.y != 0)
        {
                        
 
        }*/
    }
}
