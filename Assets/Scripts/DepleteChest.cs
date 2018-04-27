using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepleteChest : MonoBehaviour {

    public bool hasGold = true;
    float dist;

    [SerializeField]
    Sprite emptyChest;

    [SerializeField]
    float timeToDeplete = 5.0f;
    private float timeRemaining;

    private SpriteRenderer spriteRenderer;

    List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        timeRemaining = timeToDeplete;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        enemies.Clear();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

        dist = ShortestDistance(enemies);

        
        if(dist < 1.0f && timeRemaining >= 0)
        {
            timeRemaining -= Time.fixedDeltaTime;
        }
        //else if(timeRemaining < timeToDeplete)       Uncomment to make chests regenerate time until depletion
        //{
        //    timeRemaining += Time.fixedDeltaTime;
        //}

        if(timeRemaining < 0)
        {
            spriteRenderer.sprite = emptyChest;
            hasGold = false;
        }

        enemies.Clear();
    }

    float ShortestDistance(List<GameObject> enemies)
    {
        float shortest_dist = Mathf.Infinity;
        
        float dist;

        for(int i = 0; i < enemies.Count; i++)
        {
            dist = (transform.position - enemies[i].transform.position).magnitude;

            if(dist < shortest_dist)
            {
                shortest_dist = dist;
            }
        }

        return shortest_dist;
    }
}
