using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClosestChest : MonoBehaviour {

    List<GameObject> chests = new List<GameObject>();

    string closestChest;

    GameObject targetChest;

    [SerializeField]
    private float speed = 0.1f;

    [SerializeField]
    Sprite emptyChest;


    void OnEnable() {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;

        chests.AddRange(GameObject.FindGameObjectsWithTag("Chest"));

        for(int i = 0; i < chests.Count; i++)
        {
            if (chests[i].GetComponent<SpriteRenderer>().sprite == emptyChest)
            {
                chests.RemoveAt(i);
                i--;
            }
        }

        closestChest = ShortestDistance(chests);

        targetChest = GameObject.Find(closestChest);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(transform.position.y < -8f)
        {
            
            transform.position = new Vector3(Random.Range(-10f, 19f), -6f, 0f);
            
            gameObject.SetActive(false);

        }

        Vector3 distance = (targetChest.transform.position - transform.position);

        if(distance.magnitude > 1f && gameObject.GetComponent<Rigidbody2D>().gravityScale == 0f)
        {
            transform.position += distance.normalized * speed;
        }

        if (targetChest.GetComponent<SpriteRenderer>().sprite == emptyChest)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
	}

    string ShortestDistance(List<GameObject> chests)
    {
        float shortest_dist = Mathf.Infinity;
        float dist;
        string name = "";

        for (int i = 0; i < chests.Count; i++)
        {
            dist = (transform.position - chests[i].transform.position).magnitude;

            if (dist < shortest_dist)
            {
                shortest_dist = dist;
                name = chests[i].name;
            }
        }

        return name;
    }
}
