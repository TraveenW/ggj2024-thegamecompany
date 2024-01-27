using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMoney : MonoBehaviour
{
    [SerializeField] float force = 5f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
