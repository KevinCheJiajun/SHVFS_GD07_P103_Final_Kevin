using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Sword : MonoBehaviour
{
    public KeyCode Attack;
    public KeyCode Up;
    public KeyCode Left;
    public KeyCode Right;
    public float AttackSpeed;
    private bool canAttack, canTurnLeft, canTurnUp, canTurnRight;
    private Vector3 targetRotation;
    private Quaternion targetRot = Quaternion.Euler(90, 0, 0);
    public float TurningAngle_x = 90f;
    public float TurningAngle_z = 90f;
    private float timerControl;

    Collider sword;
    private void Awake()
    {
        sword = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        SwordAttackInputCheck();
        SwordAttack();
        SwordTuenInputCheck();
        SwordTurn();
    }

    public void SwordAttack()
    {
        if (!canAttack) return;

        var previousRot = transform.localRotation;

        if (transform.localRotation.eulerAngles.x == 0)
        {
            timerControl = 0;
        }

        targetRot = Quaternion.Euler(90, 0, 0);

        timerControl += Time.deltaTime;

        transform.localRotation = Quaternion.Lerp(previousRot, targetRot, timerControl);

        if (transform.localRotation == targetRot)
        {
            timerControl = 0;
            canAttack = false;
            sword.isTrigger = false;
        }
    }
    public void SwordAttackInputCheck()
    {
        if (Input.GetKeyDown(Attack))
        {
            canAttack = true;
            timerControl = 0;
            sword.isTrigger = true;
        }
    }
    public void SwordTurn()
    {
        if (canAttack) return;

        if (canTurnLeft)
        {
            targetRotation = new Vector3(0, 0, 90);
            canTurnLeft = false;
        }
        if (canTurnUp)
        {
            targetRotation = new Vector3(0, 0, 0);
            canTurnUp = false;
        }
        if (canTurnRight)
        {
            targetRotation = new Vector3(0, 0, -90);
            canTurnRight = false;
        }

        transform.localRotation = Quaternion.Euler(targetRotation);
    }
    public void SwordTuenInputCheck()
    {
        if (Input.GetKeyDown(Left))
            canTurnLeft = true;
        else if (Input.GetKeyDown(Up))
            canTurnUp = true;
        else if (Input.GetKeyDown(Right))
            canTurnRight = true;
    }
}
