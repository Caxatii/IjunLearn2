﻿using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(MeshRenderer))]
public class CubeView : MonoBehaviour
{
    public Cube Cube {  get; private set; }

    public Rigidbody Body {  get; private set; }

    public void Initialize(Cube cube)
    {
        if(Cube == null)
            Cube = cube;
    }

    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        Body = GetComponent<Rigidbody>();
    }
}
