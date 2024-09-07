using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panorama : MonoBehaviour
{
    void Update()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        cam.transform.Rotate(new Vector3(0F, 1F/4, 0F));
    }
}
