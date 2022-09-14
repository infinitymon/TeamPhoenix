using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerinfo : MonoBehaviour
{
    public Text scoreText;
    public float score;
    public float scoreincrementpersecond;
    public float health;
    public forwardMovement movement;
    void Start()
    {
        score = 0f;
        health = 100f;
        if(movement.speed == 4)
        {
          scoreincrementpersecond = 1f;
        }
        else if(movement.speed == 6)
        {
          scoreincrementpersecond = 2f;
        }
        else if (movement.speed == 8)
        {
            scoreincrementpersecond = 4f;
        }

    }

    // Update is called once per frame
   private void Update()
    {
        scoreText.text = "Score " +(int)score;
        score += scoreincrementpersecond * Time.deltaTime; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacles")
        {
            health = health - 10;
        }
    }
}
