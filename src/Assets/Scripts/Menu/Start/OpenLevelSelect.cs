using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenLevelSelect : MonoBehaviour
{
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate {
            SceneManager.LoadScene("LevelSelect");
            Cursor.lockState = CursorLockMode.None;
        });
    }
}
