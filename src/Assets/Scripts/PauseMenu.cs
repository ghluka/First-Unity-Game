using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = gameObject.transform.parent.parent.parent.GetComponent<Canvas>();
        canvas.enabled = false;

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate {
            canvas.enabled = false;
        });
    }

    void Update()
    {
        Canvas canvas = gameObject.transform.parent.parent.parent.GetComponent<Canvas>();
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
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}