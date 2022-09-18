using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerinfo : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    public Text trashText;
    public static float score;
    [SerializeField] float scoreincrementpersecond;
    [SerializeField] float health;
    public static float trashcollected;
    [SerializeField] PlayerMovement movement;
    //private PlayerMovement movement;
    
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
        healthText.text= "Health "+(int)health;
        trashText.text = "Trash " + (int)trashcollected;
        score += scoreincrementpersecond * Time.deltaTime;
        if (movement.speed < 2)
        {
            scoreincrementpersecond = 1f;
        }
        else if (movement.speed == 4)
        {
            scoreincrementpersecond = 2f;
        }
        else if (movement.speed == 6)
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
        if(collisionInfo.collider.tag == "trash")
        {
            trashcollected=trashcollected+1;
        }
    }

  
}
