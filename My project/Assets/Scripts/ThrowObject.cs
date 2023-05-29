using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 forceDirection;
    [SerializeField]
    private float throwForce;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawRay(transform.position,forceDirection*throwForce);
    }

    public void Throw()
    {
        rb.AddForce(forceDirection* throwForce, ForceMode.Impulse);
    }
}
