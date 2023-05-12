using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar: MonoBehaviour
{
    public Bala bala;
    public KeyCode shootKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        bala.Shoot();
    }
}

