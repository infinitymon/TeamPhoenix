using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    [SerializeField] GameObject junk;
    [SerializeField] playerinfo playerscript;
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
          //  playerinfo info = collider.GetComponent<playerinfo>();
                playerinfo.score = playerinfo.score + 10;
                junk.SetActive(false);
            playerinfo.trashcollected = playerinfo.trashcollected + 1;

        }
    }
}
