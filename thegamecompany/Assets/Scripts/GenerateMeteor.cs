using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMeteor : RaycastSelect
{
    [SerializeField] Transform generateTransform;
    [SerializeField] GameObject meteor;
    [SerializeField] Transform rock;
    bool canGenerate = true;

    private GameObject newMeteor;

    protected override void OnRaycast()
    {
        if (canGenerate)
        {
            newMeteor = Instantiate(meteor, generateTransform.position, generateTransform.rotation) as GameObject;
            newMeteor.transform.position = generateTransform.position;
            newMeteor.GetComponent<Meteor>().target = rock.position;
            canGenerate = false;
        }
    }
}
