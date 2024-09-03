using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        int current = Int16.Parse(button.name.Split("Level")[1]);
        int completed = PlayerPrefs.GetInt("levelsDone") + 1;
        if (completed < current)
        {
            button.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            if (completed == current)
            {
                button.GetComponent<Image>().color = Color.yellow;
            }
            button.onClick.AddListener(delegate {
                SceneManager.LoadScene(button.name);
            });
        }
    }
}
