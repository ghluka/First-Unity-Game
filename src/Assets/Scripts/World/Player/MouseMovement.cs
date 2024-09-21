using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    float xRotation = 20f;
    float YRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity");
        if (mouseSensitivity == 0) {
            PlayerPrefs.SetFloat("mouseSensitivity", .5f);
            mouseSensitivity = .5f;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89.99f, 89.99f);
        YRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);
    }
}