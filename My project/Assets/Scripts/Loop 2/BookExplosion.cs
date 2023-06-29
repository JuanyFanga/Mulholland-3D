using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookExplosion : MonoBehaviour
{
    [SerializeField]
    private AudioClip bookPatear;
    [SerializeField]
    private Transform explosionOrigin;

    [SerializeField]
    private float explosionForce = 4;
    [SerializeField]
    private float explosionRange = 4;

    private AudioSource aus= new AudioSource();

    private void Awake()
    {
        aus = gameObject.AddComponent<AudioSource>();
        aus.clip = bookPatear;
        aus.volume = Random.Range(0.1f,0.4f);
    }

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
    public void Explosion()
    {
        aus.pitch = Random.Range(0.6f, 1.4f);
        aus.Play();
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
