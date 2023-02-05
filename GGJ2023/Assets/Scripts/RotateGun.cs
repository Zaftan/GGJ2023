using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class RotateGun : MonoBehaviour
{
    void Update()
    {
        transform.rotation = LookAt2D.LookAtMouse(transform);
    }
}
