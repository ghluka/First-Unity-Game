using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Punch : MonoBehaviour
{
    bool swinging = false;
    bool returning = false;

    int swingSpeed = 16;

    float angleEnd = 100;

    IEnumerator Swing()
    {
        swinging = true;

        Image hand = gameObject.GetComponent<Image>();

        for (int i = 1; i < swingSpeed; i++)
        {
            if (hand.rectTransform.rotation.z <= angleEnd)
            {
                hand.rectTransform.anchoredPosition3D += new Vector3(-75F / swingSpeed, -65F / swingSpeed, 0F);
                hand.rectTransform.Rotate(new Vector3(0F, 0F, 25.5F / swingSpeed));

                yield return new WaitForEndOfFrame();
            }
        }

        if (angleEnd == 100)
            angleEnd = hand.rectTransform.rotation.z;

        returning = true;
        swingSpeed = 16;

        for (int i = 1; i < swingSpeed; i++)
        {
            if (returning && hand.rectTransform.rotation.z >= 0.01)
            {
                hand.rectTransform.anchoredPosition3D -= new Vector3(-75F / swingSpeed, -65F / swingSpeed, 0F);
                hand.rectTransform.Rotate(new Vector3(0F, 0F, -25.5F / swingSpeed));

                yield return new WaitForEndOfFrame();
            }
        }

        swinging = false;
        returning = false;
    }

    private void Start()
    {
        Image hand = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (swinging && !returning)
                return;

            if (returning)
            {
                swingSpeed = 1;
                returning = false;
            }

            StartCoroutine("Swing");
        }
    }
}
