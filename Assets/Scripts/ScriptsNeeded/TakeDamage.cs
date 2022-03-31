using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerInputComponent_Live>())
        {
            Debug.Log("Sh*t, you got me");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


    }
}
