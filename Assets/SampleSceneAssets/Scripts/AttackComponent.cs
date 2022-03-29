using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackComponent : MonoBehaviour
{
    public Guid iD;
    public GameObject attacker;
    public float attackActiveTimer;
    public float attackActiveTime;
    public float attackPower;
    public Guid guid;

    private void OnEnable()
    {
        iD = Guid.NewGuid();
        attacker.SetActive(false);
    }

    void Update()
    {
        if (attackActiveTimer <  0f)
        {
            attackActiveTimer = 0f;
        }

        attackActiveTimer -= Time.deltaTime;
        attacker.transform.localScale = Vector3.one * attackActiveTimer / attackActiveTime;
        if(attackActiveTimer > 0f)
        {
            attacker.SetActive(true);
            return;
        }
        attacker.SetActive(false);
        if (!Input.GetMouseButtonDown(0)) return;
        attackActiveTimer = attackActiveTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!other.GetComponent<AttackableComponent>()) return;
        //if (other.GetComponent<AttackableComponent>().GUID == guid) return;
        //other.GetComponent<Rigidbody>().AddForce(transform.forward * AttackPower, For);
    }
}
