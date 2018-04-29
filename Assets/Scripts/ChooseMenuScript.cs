using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMenuScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Scenes/Game_Jam");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SceneManager.LoadScene("Scenes/Level1");
        }
    }
}
