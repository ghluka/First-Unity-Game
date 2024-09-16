using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    void Start()
    {
        Slider slider = gameObject.GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("mouseSensitivity");
        slider.onValueChanged.AddListener(delegate {
            PlayerPrefs.SetFloat("mouseSensitivity", slider.value);
        });
    }
}