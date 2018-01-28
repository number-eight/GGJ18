using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
	public void LoadScene(int level)
    {
        //Application.LoadLevel(level);
        SceneManager.LoadScene(level);
    }
    
    void Update()
    {
        // close the application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
