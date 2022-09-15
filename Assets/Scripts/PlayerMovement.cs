using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    [SerializeField] bool movement;
    [SerializeField] float speed ;
    [SerializeField] Rigidbody rigidbody;
    float horizontalInput;
    public float horizontalMultiplier = 4f;
    [SerializeField] float maxSpeed = 10f;
    void Start()
    {
        speedModifier = 0.01f;
        speed = 1.1f;
        movement = true ;
    }

    // Update is called once per frame
    void Update()
    {

        /*  Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
          Vector3 horizontalMove= transform.right * horizontalInput * speed * Time.fixedDeltaTime*horizontalMultiplier;
          rigidbody.MovePosition(rigidbody.position + forwardMove + horizontalMove);*/


        // horizontalInput = Input.GetAxis("Horizontal");
        if(movement)
        transform.Translate(Vector3.forward * Time.deltaTime * horizontalMultiplier * speed, Space.World);

        if (Input.touchCount > 0)
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

    private void FixedUpdate()
    {
        if(speed<maxSpeed){
            speed = speed + 0.01f;
        }

     //   if(movement){

          /*  Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove= transform.right * horizontalInput * speed * Time.fixedDeltaTime*horizontalMultiplier;
            rigidbody.MovePosition(rigidbody.position + forwardMove + horizontalMove); */
     //   }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            //Vector3.forward = -2 ;
            //movement = false;
            //Debug.Log("obstacle hit");
            movement = false ;
            //rigidbody.position.z = rigidbody.position.z - 1;
        }
        else {
            movement = true ;
        }

    }
}
