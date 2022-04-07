using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBall : MonoBehaviour
{
    PlayerHealthSystem player_1;
    PlayerHealthSystem player_2;
    public int HealingNum;
    private void Start()
    {
        player_1 = GameObject.FindGameObjectWithTag("Player_1_Health").GetComponent<PlayerHealthSystem>();
        player_2 = GameObject.FindGameObjectWithTag("Player_2_Health").GetComponent<PlayerHealthSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_1>())
        {
            player_1.Heal(HealingNum);
            Destroy(this.gameObject);
        }
        if (other.gameObject.GetComponent<Player_2>())
        {
            player_2.Heal(HealingNum);
            Destroy(this.gameObject);
        }
    }
}
