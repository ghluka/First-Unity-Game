using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{

    private void Start()
    {
        string[] splashes = new string[] {
            "My first Unity game!",
            "Open source!",
            SystemInfo.graphicsDeviceType.ToString() + "!",
            "Hello world.",
            "Music by Zaitch!",
            "<color=#00FF00>Red!</color>",
            "<color=#0000FF>Green!</color>",
            "<color=#FF0000>Blue!</color>",
            "Browser edition!",
            "Mine Parkour!",
            "Written in C#!",
            "Licensed under Apache 2.0!",
            "Redistribute!",
            SceneManager.sceneCountInBuildSettings - 2 + " levels!",
        };

        Text text = gameObject.GetComponent<Text>();
        text.text = splashes[UnityEngine.Random.Range(0, splashes.Length)];

        DateTime now = DateTime.Now;
        if (now.Month == 12 && (now.Day == 25 || now.Day == 24))
            text.text = "Merry Christmas!";
        else if (now.Month == 10 && now.Day == 31)
            text.text = "Trick or treat!";
        else if (now.Month == 1 && now.Day == 1)
            text.text = "Happy new year!";
    }
}
