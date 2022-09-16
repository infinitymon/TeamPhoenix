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

}
