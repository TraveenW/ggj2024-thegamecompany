using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMeteor : RaycastSelect
{
    [SerializeField] Transform generateTransform;
    [SerializeField] GameObject meteor;
    bool canGenerate = true;

    protected override void OnRaycast()
    {
        if (canGenerate)
        {
            Instantiate(meteor, generateTransform.position, generateTransform.rotation);
            canGenerate = false;
        }
    }
}
