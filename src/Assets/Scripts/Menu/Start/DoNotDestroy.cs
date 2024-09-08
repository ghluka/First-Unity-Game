using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObject.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
