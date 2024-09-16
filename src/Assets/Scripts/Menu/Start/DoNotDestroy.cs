using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if (musicObject.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
