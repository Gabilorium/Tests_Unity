using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentDash : MonoBehaviour {
 
    public Vector3 moveDirection;
 
     public const float maxDashTime = 1.0f;
     public float dashDistance = 10;
     public float dashStoppingSpeed = 0.1f;
     public UnblockDash _jugador;
    
     float currentDashTime = maxDashTime;
     float dashSpeed = 10;
     CharacterController controller;
    
     
 
     private void Awake()
     {
         controller = GetComponent<CharacterController>();
     }
 
     // Update is called once per frame
     void Update () {
        if(_jugador.DashActivo == true){
            UseDash();
           
        
        }
      
     }

     void UseDash()
     {
        if (Input.GetButtonDown("Dash")) //space mouse button
         {
            Debug.Log("Dash");
            currentDashTime = 0; 

         }
         if(currentDashTime < maxDashTime)
         {
             moveDirection = transform.forward * dashDistance;
             currentDashTime += dashStoppingSpeed;
         }
         else
         {
             moveDirection = Vector3.zero;
         }
         controller.Move(moveDirection * Time.deltaTime * dashSpeed); 
     }

   
    
 }
