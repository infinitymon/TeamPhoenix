using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class load_level : MonoBehaviour
{
    public Text score;
    public Text trash;
    void Start()
    {
        score.text = "Your Score : " + (int)playerinfo.score;
        trash.text = "Trash Collected: " + (int)playerinfo.trashcollected;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            nextlevel();
        }
    }

    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }
}
