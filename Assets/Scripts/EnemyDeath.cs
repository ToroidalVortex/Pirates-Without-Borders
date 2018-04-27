using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

    private void FixedUpdate()
    {
        if (transform.position.y < -8f)
        {
            transform.position = new Vector3(Random.Range(-10f, 19f), -6f, 0f);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.collider.name;
        if (name.Equals("Bullet(Clone)") || name.Equals("Bullet"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
    }

}
