using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform jugador;
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        // Verifica que se haya asignado un objeto jugador
        if (jugador == null)
        {
            return;
        }

        // Ajusta la posición de la cámara
        Vector3 offset = new Vector3(0, 10, -5); // Ajusta estos valores para cambiar la posición relativa de la cámara
        transform.position = jugador.position + offset;

        // Ajusta la rotación de la cámara para que mire hacia el jugador
        transform.LookAt(jugador.position);
    }

}
