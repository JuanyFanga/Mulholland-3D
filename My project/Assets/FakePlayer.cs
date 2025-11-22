using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayer : MonoBehaviour
{
    //Para debug nomás, deberíamos usar otra cosa
    public Rigidbody rb;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = Vector3.right;
        }
    }
}
