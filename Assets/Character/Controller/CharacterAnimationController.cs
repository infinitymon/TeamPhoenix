using UnityEngine;

public class CharacterAnimationController
{
    private Animator _animator;

    private static int IdleKey = Animator.StringToHash("Idle");
    private static int ScoopKey = Animator.StringToHash("Scoop");
    private static int CollideKey = Animator.StringToHash("Collide");
    private static int WalkKey = Animator.StringToHash("Walk");

    public CharacterAnimationController(Animator animator){
        _animator = animator ;
    }

    public void PlayAnimation(AnimationType type){
        switch (type){
            case AnimationType.Idle:
                PlayIdle();
                break ;
            case AnimationType.Collide:
                PlayCollide();
                break ;
            case AnimationType.Scoop:
                PlayScoop();
                break ;
            case AnimationType.Walk:
                PlayWalk();
                break ;
        }
    }

    private void PlayIdle(){
        _animator.SetTrigger(IdleKey) ;
    }

    private void PlayScoop(){
        _animator.SetTrigger(ScoopKey) ;
    }

    private void PlayCollide(){
        _animator.SetTrigger(CollideKey) ;
    }

    private void PlayWalk(){
        _animator.SetTrigger(WalkKey) ;
    }

}
