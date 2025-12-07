using System;
using JetBrains.Annotations;
using UnityEngine;

public class ZoomJugador : MonoBehaviour
{
    public Controles control;
    public float zoom;

    public float zoomMin = 0.5f;
    public float zoomMax = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        control = new Controles();
    }
    void OnEnable()
    {
        control.Enable();        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       zoom = control.Camera.Zoom.ReadValue<float>();
    }
}
