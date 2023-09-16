using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 15f;
    public float minRotationX = -30f;
    public float maxRotationX = 50f;

    void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX);

        //rotationY += Input.GetAxis("Mouse X") * sensitivity;

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
    }
}
