using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SwordThing>())
        {
            Debug.Log("Sh*t, you got me");
        }
    }
}
