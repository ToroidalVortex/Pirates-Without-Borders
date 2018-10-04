using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChestPool2 : MonoBehaviour
{
    public int cycles;
    List<GameObject> chests;

    [SerializeField]
    Sprite emptyChest;

    // Use this for initialization
    void Start()
    {
        if (chests == null)
        {
            chests = new List<GameObject>();
        }
        chests.AddRange(GameObject.FindGameObjectsWithTag("Chest"));
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < chests.Count; i++)
        {
            if (chests[i].GetComponent<SpriteRenderer>().sprite == emptyChest)
            {
                chests.RemoveAt(i);
                i--;
            }
        }

        // Change scenes after 60 seconds
        

        if (cycles >= 3000)
            SceneManager.LoadScene("Scenes/Level_menu");
        else
            cycles++;


        GameObject.Find("Chests").GetComponent<Text>().text = "Chests: " + chests.Count;

        if (chests.Count == 0)
        {
            SceneManager.LoadScene("Scenes/Level_menu");
        }


    }

}
