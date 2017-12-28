using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int maxDepth;
    public float childScale;

    private int depth;
    private Vector3 direction;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }

    private IEnumerator CreateChildren()
    {
        yield return new WaitForSeconds(1f);

        new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.down);
        new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.up);
        new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.right);
        new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.left);
        new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.back);
        new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.forward);

    }

    void Initialize(Fractal parent, Vector3 direction)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = direction * (0.5f + 0.5f * childScale);
        this.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        transform.localRotation = Quaternion.Euler(0f, 10f * Time.time, 0f);
    }
}
