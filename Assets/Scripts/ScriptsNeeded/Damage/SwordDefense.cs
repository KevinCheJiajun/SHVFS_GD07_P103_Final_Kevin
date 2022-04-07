using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDefense : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SwordThing>())
        {
            Debug.Log("Nop");
        }
    }
}
