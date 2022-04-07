using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    PlayerHealthSystem player_1;
    PlayerHealthSystem player_2;
    public GameObject Player1Win;
    public GameObject Player2Win;

    private bool getBolck = false;
    private void Start()
    {
        player_1 = GameObject.FindGameObjectWithTag("Player_1_Health").GetComponent<PlayerHealthSystem>();
        player_2 = GameObject.FindGameObjectWithTag("Player_2_Health").GetComponent<PlayerHealthSystem>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player_1>())
        {
            if (getBolck == true)
            {
                getBolck = false;
                return;
            }
            player_1.GetHurt(Player2Win);
        }
        if (collision.gameObject.GetComponent<Player_2>())
        {
            if (getBolck == true)
            {
                getBolck = false;
                return;
            }
            player_2.GetHurt(Player1Win);
        }
        if (collision.gameObject.GetComponent<SwordThing>())
        {
            getBolck = true;
        }
    }
}
