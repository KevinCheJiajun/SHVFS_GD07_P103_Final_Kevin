using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    UISystem player_1;
    UISystem player_2;
    public GameObject Player1Win;
    public GameObject Player2Win;
    private void Start()
    {
        player_1 = GameObject.FindGameObjectWithTag("Player_1_Health").GetComponent<UISystem>();
        player_2 = GameObject.FindGameObjectWithTag("Player_2_Health").GetComponent<UISystem>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player_1>())
        {
            player_1.GetHurt(Player2Win);
        }
        if (collision.gameObject.GetComponent<Player_2>())
        {
            player_2.GetHurt(Player1Win);
        }
    }
}
