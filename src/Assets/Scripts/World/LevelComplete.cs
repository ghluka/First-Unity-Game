using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int current = Int16.Parse(SceneManager.GetActiveScene().name.Split("Level")[1]);
            int completed = PlayerPrefs.GetInt("levelsCompleted");
            if (completed < current)
                PlayerPrefs.SetInt("levelsCompleted", current);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
