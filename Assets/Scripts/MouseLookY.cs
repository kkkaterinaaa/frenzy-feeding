using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookY : MonoBehaviour
{
    public float sensitivity = 200f;

    public float maxAngle = 90;

    public float minAngle = -90;
    void Update()
    {
        _verticalRot -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        _verticalRot = Mathf.Clamp(_verticalRot, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(_verticalRot, 0, 0);
    }

    private float _verticalRot = 0;
}