using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semueve : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w")||Input.GetKey("s")||Input.GetKey("a")||Input.GetKey("d"))
        {
            anim.SetBool("IsRunW",true);
        }
         if(!Input.GetKey("w")&&!Input.GetKey("s")&&!Input.GetKey("a")&&!Input.GetKey("d"))
        {
            anim.SetBool("IsRunW",false);
        }
    }
}
