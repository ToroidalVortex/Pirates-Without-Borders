﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashPageScript : MonoBehaviour {
	
	void Update () {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Scenes/Game_Jam");
        }
	}
}
