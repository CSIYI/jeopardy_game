using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditQuestionButton : MonoBehaviour
{
	public JQuestion QuestionInfo;
	
	// Use this for initialization
	void Start ()
	{
	    ManualUpdate();
	}

    public void ManualUpdate()
    {
        Text text = gameObject.transform.GetComponentInChildren<Text>();
        text.text = "$" + QuestionInfo.Value;
    }

    public void OnClick()
    {
        var controller = this.transform.parent.parent.parent.parent.GetComponent<CreateGameController>();
        controller.CurrentEditingQuestion = QuestionInfo;
        controller.CallbackMethod = ManualUpdate;
        controller.QuestionButtonClick();
    }
}
