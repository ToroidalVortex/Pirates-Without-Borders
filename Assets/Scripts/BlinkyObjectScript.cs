using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkyObjectScript : MonoBehaviour {

    public float blinkySpeed = 5f;

    float num;
    Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        num = Mathf.Sin(Time.fixedTime * blinkySpeed);
        if (num > 0)
            textComponent.text = "Press Any Key";
        else
            textComponent.text = "";
    }
}
