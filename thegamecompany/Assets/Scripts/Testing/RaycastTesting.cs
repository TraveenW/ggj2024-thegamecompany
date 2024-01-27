using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTesting : RaycastSelect
{
    protected override void OnRaycast(GameObject gameObject)
    {
        Debug.Log("Looking at");
    }
}
