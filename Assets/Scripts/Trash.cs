using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    [SerializeField] GameObject junk;

    void OnTriggerEnter2D(){
        if(GetComponent<Collider>().gameObject.tag == "Player"){
           /* PlayerInfo info = collider.GetComponent<PlayerInfo>();
            if(info.addGold(value)){
                info.setCarryGoldTrue();*/
                Destroy(junk);
        }
    }
}
