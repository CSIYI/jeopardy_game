using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayState : TimerBase
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        ai.StartCountDown();
        ai.AudienceObject.SendMessage("changePanel", "Question"); //audience screen show quesiton
        ai.startButton.SetActive(false);
        ai.pauseButton.SetActive(true);
        ai.resetButton.SetActive(false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPlaying", ai.IsPlaying);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}


}
