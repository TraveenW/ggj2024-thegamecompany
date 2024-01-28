using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float dragAmount;

    [SerializeField] Transform orientation;

    [SerializeField] float targetCounter;

    float horizontalInput;
    float verticalInput;

    float counter = 0f;
    bool isCounting = false;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.drag = dragAmount;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (isCounting)
            counter += Time.deltaTime;
    }

    void FixedUpdate()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(moveDirection.magnitude > 0)
        {
            if (!isCounting)
                isCounting = true;

            if(counter >= targetCounter)
            {
                AudioManager.Instance.PlayFootsteps();
                counter = 0f;
            }
        }
        else
        {
            isCounting = false;
            counter = 0f;
        }

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
