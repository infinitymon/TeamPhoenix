using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    public bool movement;
    public float speed ;
    [SerializeField] Rigidbody rigidbody;
    float horizontalInput;
    public float horizontalMultiplier = 4f;
    [SerializeField] float maxSpeed ;
    //public float radius = 1.0f;
    //public float power = -10.0f;

    [SerializeField] private Animator _animator;
    private CharacterAnimationController _animationcontroller ;

    void Start()
    {
        speedModifier = 0.01f;
        speed = 1.1f;
        movement = true ;
        _animationcontroller = new CharacterAnimationController(_animator);
        //_animationcontroller.PlayAnimation(AnimationType.Walk);
    }

    // Update is called once per frame
    void Update()
    {

        /*  Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
          Vector3 horizontalMove= transform.right * horizontalInput * speed * Time.fixedDeltaTime*horizontalMultiplier;
          rigidbody.MovePosition(rigidbody.position + forwardMove + horizontalMove);*/


        // horizontalInput = Input.GetAxis("Horizontal");
        if(movement){
            transform.Translate(Vector3.forward * Time.deltaTime * horizontalMultiplier * speed, Space.World);
            
        }
        
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
        if(speed<maxSpeed && movement){
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
       // if(collision.gameObject.tag != "Trash"  &&  collision.gameObject.tag != "Environment")
        if(collision.gameObject.tag == "obstacles")
        {
            //Vector3 explodeposition = transform.position;
            //private float thrust = -2.0f ;
            rigidbody.AddForce(0, 1000, -10000f, ForceMode.Impulse) ;
            //_animationcontroller.PlayAnimation(AnimationType.Collide);
            //_animationcontroller.PlayAnimation(AnimationType.Idle);
            movement = false ;
            speed = 1.1f;
            //rigidbody.position.z = rigidbody.position.z - 1;
        }
        else {
            movement = true ;
            //_animationcontroller.PlayAnimation(AnimationType.Walk);
        }

    }

}