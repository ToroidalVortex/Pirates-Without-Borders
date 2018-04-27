using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScript : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D focus;

    private Vector3 cameraPos;
    private Vector3 rbPos;
    private Vector3 temp;

    [SerializeField]
    private float lerpiness = 0.08f;

    private void FixedUpdate()
    {
        cameraPos = transform.position;
        rbPos = focus.transform.position;

        temp = Vector3.Lerp(cameraPos, rbPos, lerpiness);
        transform.position = new Vector3(temp.x, cameraPos.y, cameraPos.z);
    }
}
