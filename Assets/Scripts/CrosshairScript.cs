using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {

    Camera cam;
    Vector3 mousePos;

    private void Start()
    {
        Cursor.visible = false;
        cam = GameObject.FindObjectOfType<Camera>();
    }

    private void OnDisable()
    {
        Cursor.visible = true;
    }

    private void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;
    }
}
