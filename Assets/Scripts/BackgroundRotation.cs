using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotation : MonoBehaviour {

    [SerializeField]
    float speed = 5f;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = speed;
    }
}
