using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour
{
    public GameObject levelTransitionUI;
    public playerinfo info;
    [SerializeField] Text scoretext;
    [SerializeField] Text trashtext;
    [SerializeField] bool gameon;
   

    private void Start()
    {
        gameon = true;
        levelTransitionUI.SetActive(false); 
    }

    private void Update()
    {
        nextlevel();
    }

    private void nextlevel()
    {
        if (Input.touchCount > 0 && gameon == false)
        {
           
                Time.timeScale = 1;
                levelTransitionUI.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
               
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="levelfinisher")
        {
            levelTransitionUI.SetActive(true);
            scoretext.text = "Your Score : " + (int)playerinfo.score;
            trashtext.text = "Trash Collected : " + (int)playerinfo.trashcollected;
            gameon = false;
            Time.timeScale = 0;
            nextlevel();
        }
    }
}
