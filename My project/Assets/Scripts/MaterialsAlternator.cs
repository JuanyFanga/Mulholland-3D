using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsAlternator : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private float cooldown=0.2f;

    private MeshRenderer mesh;

    private float timer;
    private int index;

    private void Awake()
    {
        timer = cooldown;
        mesh = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        timer = timer > 0 ? timer - Time.deltaTime : 0;
        if (timer==0)
        {
            timer = cooldown;

            index = index == 1 ? 0 : 1;
            mesh.material = materials[index];
        }
    }
}
