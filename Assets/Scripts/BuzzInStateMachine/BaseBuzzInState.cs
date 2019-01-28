using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuzzInState : StateMachineBehaviour
{
    protected AIBuzzIn ai;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai = animator.gameObject.GetComponent<AIBuzzIn>();
    }
}
