using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.InputSystem.OnScreen;

public class FollowCamera : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    
    private float zoom = 1f;
    private float zoomMin = 2f;

    private float zoomMax = 5f;

    private float suavizadoZoom = 10f;
    private Controles controles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controles = new Controles();
    }
    private void OnEnable()
    {
        controles.Enable();        
    }

    private void OnDisable()
    {
        
    }
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        float scrollValue = controles.Camera.Zoom.ReadValue<float>();
        zoom -= scrollValue / suavizadoZoom;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
        Vector3 zoomFinal = offset * zoom;
        transform.position = player.transform.position + zoomFinal;
    }
    private void OnScroll()
    {
        
    }
}
