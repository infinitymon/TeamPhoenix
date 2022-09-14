using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    [SerializeField] GameObject junk;

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            playerinfo info = collider.GetComponent<playerinfo>();
                info.score = info.score + 10;
                junk.SetActive(false);
        }
    }
}
