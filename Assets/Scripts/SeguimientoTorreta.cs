using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoTorreta : MonoBehaviour
{
    public Transform _target;
    public float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 targetOrientation = _target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.green);
        
        transform.rotation = Quaternion.LookRotation(targetOrientation );
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, rotationSpeed * Time.deltaTime);
}
}

