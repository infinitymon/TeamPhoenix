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
    private PlayerMovement playermovement ;
    public GameObject MainCam ;
    public GameObject SecondCam ;
    public GameObject obstacles ;
    public GameObject greenry; 
    public GameObject ScoringUI ;
    public GameObject GameOverUI;
   

    private void Start()
    {
        gameon = true;
        levelTransitionUI.SetActive(false); 

        playermovement = new PlayerMovement() ;
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
        Scene scene = SceneManager.GetActiveScene() ;
        if(collision.gameObject.tag=="levelfinisher" && scene.name == "Level_5"){
            MainCam.SetActive(false) ;
            StartCoroutine(Example());
            SecondCam.SetActive(true) ;
            StartCoroutine(Example());
            obstacles.SetActive(false) ;
            StartCoroutine(Example());
            greenry.SetActive(true) ;
            Time.timeScale=0f ;
            GameOverUI.SetActive(true);
            ScoringUI.SetActive(false);


        }
        else if(collision.gameObject.tag=="levelfinisher")
        {
            levelTransitionUI.SetActive(true);
            scoretext.text = "Your Score : " + (int)playerinfo.score;
            trashtext.text = "Trash Collected : " + (int)playerinfo.trashcollected;
            gameon = false;
            Time.timeScale = 0;
            nextlevel();
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(2);
     //   print(Time.time);
    }

    public void Restart(){
        SceneManager.LoadScene("Level_1") ;
    }
}
