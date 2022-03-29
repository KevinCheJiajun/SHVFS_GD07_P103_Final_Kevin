using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAimingComponent : MonoBehaviour
{
    public KeyCode LockAiming;
    public GameObject TargetGameObject;
    private bool IsLockAiming = false;
    private void Update()
    {
        if (IsLockAiming)
        {
            var direction = TargetGameObject.transform.position - transform.position;

            transform.forward = direction.normalized;
        }

        if (!Input.GetKeyDown(LockAiming)) return;

        IsLockAiming = !IsLockAiming;
    }
}
