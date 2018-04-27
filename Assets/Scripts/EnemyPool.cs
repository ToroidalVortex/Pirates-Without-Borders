using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPool : MonoBehaviour {

    List<GameObject> enemyPool;

    [SerializeField]
    float difficulty = 2f;

    int num = 0;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    int numberOfObjects = 1;

    void Start() {
		if(enemyPool == null)
        {
            enemyPool = new List<GameObject>();
        }

        for(int i = 0; i < numberOfObjects; i++)
        {
            var obj = Instantiate(prefab, new Vector3(Random.Range(-10,19), -6, 0), Quaternion.identity);
            obj.SetActive(false);
            enemyPool.Add(obj);
        }

	}

    private void FixedUpdate()
    {
        

        if (Time.fixedTime % difficulty == 0f)
        {
            for (int i = 0; i < Random.Range(0, 4); i++)
            {
                enemyPool[num].SetActive(true);
                num++;
                if (num == enemyPool.Count) num = 0;
            }
        }
        
    }
}
