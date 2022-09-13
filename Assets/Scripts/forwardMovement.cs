using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forwardMovement : MonoBehaviour
{
    public float speed = 8.5f;
    public Rigidbody rigidbody;
    float horizontalInput;
    public float horizontalMultiplier = 4f;
    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove= transform.right * horizontalInput * speed * Time.fixedDeltaTime*horizontalMultiplier;
        rigidbody.MovePosition(rigidbody.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
