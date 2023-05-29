using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookExplosion : MonoBehaviour
{
    [SerializeField]
    private Transform explosionOrigin;

    [SerializeField]
    private float explosionForce = 4;
    [SerializeField]
    private float explosionRange = 4;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
     
        Gizmos.DrawWireSphere(explosionOrigin.position,explosionRange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("aa");
            explosionOrigin.position= new Vector3( other.ClosestPointOnBounds(transform.position).x,explosionOrigin.position.y, other.ClosestPointOnBounds(transform.position).z);
            Explosion();
        }
    }

    [ContextMenu("Explo")]
    private void Explosion()
    {
        var rbs = transform.GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.constraints = RigidbodyConstraints.None;
          
        }
        foreach (var rb in rbs)
        {
            rb.AddExplosionForce(explosionForce, explosionOrigin.position, explosionRange);
        }
    }
}
