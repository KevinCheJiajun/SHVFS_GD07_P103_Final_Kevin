using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    void Update()
    {
        Restart();
    }
    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Final Game");
            }
        }
    }
}
