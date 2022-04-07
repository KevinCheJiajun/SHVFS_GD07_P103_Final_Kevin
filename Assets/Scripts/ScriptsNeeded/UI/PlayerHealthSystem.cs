using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    public int HealthCurrent;
    public int HealthMax;
    private Image healthBar;

    void Start()
    {
        healthBar = GetComponent<Image>();
        HealthCurrent = 5;
    }
    void Update()
    {
        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
    }
    public void GetHurt(GameObject player)
    {
        HealthCurrent--;
        if (HealthCurrent == 0)
        {
            PlayerDied(player);
        }
    }
    public void PlayerDied(GameObject player)
    {
        Time.timeScale = 0;
        player.SetActive(true);
    }
    public void Heal(int Number)
    {
        HealthCurrent += Number;
    }
}
