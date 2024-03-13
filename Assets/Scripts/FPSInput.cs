using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private CharacterController _characterController;
    public float speed = 5.0f;
    private float _gravity = -9.8f;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        speed = Input.GetKey(KeyCode.LeftShift) ? 10.0f : 5.0f;
        var horizontal = Input.GetAxis("Horizontal") * speed;
        var vertical = Input.GetAxis("Vertical") * speed;
        var movement = new Vector3(horizontal, _gravity, vertical) * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}