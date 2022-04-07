using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject ESCPauseMenu;
    void Update()
    {
        Pause();
    }
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESCPauseMenu.activeSelf)
            {
                ESCPauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else if (!ESCPauseMenu.activeSelf)
            {
                ESCPauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
