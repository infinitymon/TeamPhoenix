using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public forwardMovement movement;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag=="obstacles")
        {
            movement.enabled = false;
        }
    }


}
