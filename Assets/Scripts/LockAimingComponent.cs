using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAimingComponent : MonoBehaviour
{
    public GameObject TargetGameObject;
    public bool IsLockAiming = false;
    private void Update()
    {
        if (IsLockAiming)
        {
            var direction = TargetGameObject.transform.position - transform.position;

            transform.forward = direction.normalized;
        }

        if (!Input.GetKeyDown(KeyCode.Q)) return;

        IsLockAiming = !IsLockAiming;
    }
}
