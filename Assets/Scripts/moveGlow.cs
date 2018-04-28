using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveGlow : MonoBehaviour {

    public static int level = 1;
    Vector3 glowPos;
    Vector3 glowScale;
    float xScale = 0.19f;
    float yScale = 0.19f;
    public bool shrunk;
    public bool grown;
    // Use this for initialization
    void Start () {
        InitPos();
        level += 1;
        shrunk = false;
        grown = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(!shrunk)
            Shrink();
        else if (shrunk && !grown)
        {
            MoveGlow();
            Grow();
        }
        else if(grown && shrunk)
        {
            Debug.Log("G&S");
            ChangeScene();
        }
    }
    public void Shrink()
    {
        if (xScale <= 0.15f)
            shrunk = true;
        else
        {
            xScale -= 0.001f;
            yScale -= 0.001f;
            glowScale = new Vector3(xScale, yScale, 1f);
            transform.localScale = glowScale;
        }
    }
    public void Grow()
    {
        if (xScale >= 0.19f)
            grown = true;
        else
        {
            xScale += 0.001f;
            yScale += 0.001f;
            glowScale = new Vector3(xScale, yScale, 1f);
            transform.localScale = glowScale;
        }
    }
    public void MoveGlow()
    {
        if(level == 2)
        {
            glowPos = new Vector3(-2.25f, 0, 0);
            transform.position = glowPos;
            grown = false;
        }
        else if(level == 3)
        {
            glowPos = new Vector3(2.25f, 0, 0);
            transform.position = glowPos;
            grown = false;
        }
        else if (level == 4)
        {
            glowPos = new Vector3(6.68f, 0, 0);
            transform.position = glowPos;
            grown = false;
        }
    }
    public void ChangeScene()
    {
        Debug.Log("Scene Changed");
        if(level ==2)
            SceneManager.LoadScene("Level2");
        else if (level == 3)
            SceneManager.LoadScene("Level3");
        else if (level == 4)
            SceneManager.LoadScene("Level4");
    }
    public void InitPos()
    {
        if (level == 1)
            glowPos = new Vector3(-6.68f, 0, 0);
        else if (level == 2)
            glowPos = new Vector3(-2.25f, 0, 0);
        else if (level == 3)
            glowPos = new Vector3(2.25f, 0, 0);

        transform.position = glowPos;
    }
}
