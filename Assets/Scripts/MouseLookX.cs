using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookX : MonoBehaviour
{
    public float sensitivity = 200f;
    void Update()
    {
        var horizontalAim = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        transform.Rotate(0, horizontalAim, 0);
    }
}
