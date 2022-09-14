using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerinfo : MonoBehaviour
{
    public Text scoreText;
    [SerializeField] float score;
    [SerializeField] float scoreincrementpersecond;
    [SerializeField] float health;
    [SerializeField] float trashcollected;
    [SerializeField] forwardMovement movement;
    void Start()
    {
        score = 0f;
        health = 100f;
        trashcollected = 0f;

    }

    // Update is called once per frame
   private void Update()
    {
        scoreText.text = "Score " +(int)score;
        score += scoreincrementpersecond * Time.deltaTime;
        if (movement.speed == 4)
        {
            scoreincrementpersecond = 1f;
        }
        else if (movement.speed == 6)
        {
            scoreincrementpersecond = 2f;
        }
        else if (movement.speed == 8)
        {
            scoreincrementpersecond = 4f;
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "obstacles")
        {
            health = health - 10f;
            if(trashcollected > 0)
            {
                trashcollected = trashcollected - 1;
            }
        }
        else if(collisionInfo.collider.tag == "trash")
        {
            trashcollected++;
        }
    }
}
