using System;
using Misc;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _mousePos;
    private Vector3 _mouseWorldPos;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        ProcessInput();
    }
    
    private void Update()
    {
        RotatePlayerToMousePosition();
    }

    private void ProcessInput()
    {
        _mousePos = Input.mousePosition;
        _mousePos.z = _camera.nearClipPlane;
        _mouseWorldPos = _camera.ScreenToWorldPoint(_mousePos);
    }

    private void RotatePlayerToMousePosition()
    {
        var lookDirection = _mouseWorldPos - transform.position;
        var lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, lookAngle);
    }
}
