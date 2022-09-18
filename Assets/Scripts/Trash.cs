using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    [SerializeField] GameObject junk;
    [SerializeField] playerinfo playerscript;

    [SerializeField] private Animator _animator;
    private CharacterAnimationController _animationcontroller ;

    void Start(){
        _animationcontroller = new CharacterAnimationController(_animator);
    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
          //  playerinfo info = collider.GetComponent<playerinfo>();
                playerinfo.score = playerinfo.score + 10;
                junk.SetActive(false);
            playerinfo.trashcollected = playerinfo.trashcollected + 1;
            _animationcontroller.PlayAnimation(AnimationType.Scoop);
        }
    }
}
