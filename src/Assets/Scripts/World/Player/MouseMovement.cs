using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    float xRotation = 20f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", 0.5f);

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * 25f;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * 25f;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89.99f, 89.99f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
