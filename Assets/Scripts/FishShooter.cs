using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShooter : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject projectile;
    public float coolDown = 0.7f;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        _cooldownCounter += Time.deltaTime;
        if(_cooldownCounter > coolDown) checkForShooting();
    }
    
    private void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    
    private void checkForShooting()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Instantiate(projectile, cameraTransform.position + cameraTransform.forward, cameraTransform.rotation);
        _cooldownCounter = 0;

    }

    private float _cooldownCounter = 0;
}