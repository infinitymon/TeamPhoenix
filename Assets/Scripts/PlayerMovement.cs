using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    public forwardMovement movement;
    [SerializeField] float speed ;
    [SerializeField] Rigidbody rigidbody;
    float horizontalInput;
    public float horizontalMultiplier = 4f;
    [SerializeField] float maxSpeed = 15f;
    void Start()
    {
        speedModifier = 0.05f;
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        /*Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove= transform.right * horizontalInput * speed * Time.fixedDeltaTime*horizontalMultiplier;
        rigidbody.MovePosition(rigidbody.position + forwardMove + horizontalMove);*/

        if(Input.touchCount > 0)
        {
           touch=Input.GetTouch(0);
           if(touch.phase == TouchPhase.Moved)
            {
                transform.position=new Vector3(
                transform.position.x+touch.deltaPosition.x *speedModifier,
                transform.position.y,transform.position.z);
            }
        }
    }

    void FixedUpdate()
    {
        if(speed<maxSpeed){
            speed = speed + 0.01f;
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove= transform.right * horizontalInput * speed * Time.fixedDeltaTime*horizontalMultiplier;
        rigidbody.MovePosition(rigidbody.position + forwardMove + horizontalMove);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag=="obstacles")
        {
            movement.enabled = false;
            Debug.Log("obstacle hit");
        }
        else
        {
           // movement.enabled = true;
        }
    }
}
