using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    Canvas canvas;

    void Start()
    {
        canvas = GetCanvas();
        canvas.enabled = false;

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate
        {
            canvas.enabled = !canvas.enabled;
        });
    }

    private Canvas GetCanvas()
    {
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.CompareTag("Settings"))
                return canvas;
        }
        return null;
    }

    void Update()
    {
        if (gameObject.name != "GoBack")
            return;

        Camera camera = FindObjectOfType<Camera>();

        if (Input.GetKeyDown(KeyCode.P))
        {
            canvas.enabled = !canvas.enabled;
        }

        if (canvas.enabled)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            if (SceneManager.GetActiveScene().name.StartsWith("Level") && !SceneManager.GetActiveScene().name.EndsWith("Select"))
                Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}