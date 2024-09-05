using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Punch : MonoBehaviour
{
    bool swinging = false;

    IEnumerator Swing()
    {
        swinging = true;

        Image hand = gameObject.GetComponent<Image>();
        int swingSpeed = 16;

        for (int i = 1; i < swingSpeed; i++)
        {
            hand.rectTransform.anchoredPosition3D += new Vector3(-75F / swingSpeed, -65F / swingSpeed, 0F);
            hand.rectTransform.Rotate(new Vector3(0F, 0F, 25.5F / swingSpeed));
            yield return new WaitForEndOfFrame();
        }
        for (int i = 1; i < swingSpeed; i++)
        {

            hand.rectTransform.anchoredPosition3D -= new Vector3(-75F / swingSpeed, -65F / swingSpeed, 0F);
            hand.rectTransform.Rotate(new Vector3(0F, 0F, -25.5F / swingSpeed));
            yield return new WaitForEndOfFrame();
        }
        swinging = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !swinging)
        {
            StartCoroutine("Swing");
        }
    }
}
