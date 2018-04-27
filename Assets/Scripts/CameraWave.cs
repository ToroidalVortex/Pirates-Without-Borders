using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWave : MonoBehaviour {

    [SerializeField]
    float amplitude = 1f;

    [SerializeField]
    float speed = 0.5f;

    float verticalShift;

    private void Start()
    {
        verticalShift = transform.position.y;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, amplitude * Mathf.Sin(Time.fixedTime * speed) + verticalShift, transform.position.z);
    }

}
