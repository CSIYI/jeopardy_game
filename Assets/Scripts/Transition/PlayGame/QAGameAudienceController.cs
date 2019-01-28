using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class QAGameAudienceController : MonoBehaviour {

    public AIBuzzIn aibuzzin;
    bool isFirstShowScreen = true;
    private string question;
    private string answer;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        //GameObject.Find("AnswerPanel").GetComponentInChildren<Text>().text = "123456";
        //aibuzzin.clearBuzzes();
        //Debug.Log("QAScreen Enabled");

        if (isFirstShowScreen)
        {
            isFirstShowScreen = false;
            return;
        }

        AudienceData audienceData = AudienceData.GetInstance();
        int line = audienceData.GetQuestionLine();
        int row = audienceData.GetQuestionRow();
        if (audienceData.GetQuestionType() == 0)
        {
            question = GameData.Question[line][row].Question;
            answer = GameData.Question[line][row].Answer;
        }
        else if (audienceData.GetQuestionType() == 1)
        {
            question = GameData.DoubleQuestion[line][row].Question;
            answer = GameData.DoubleQuestion[line][row].Answer;
        }
        else
        {
            question = GameData.FinalQuestion.Question;
            answer = GameData.FinalQuestion.Answer;
        }

        GameObject.Find("AnswerPanel").GetComponentInChildren<Text>().text = question;

    }

    public void UpdateContent(bool isAnswer)
    {
        if(isAnswer)
        {
            GameObject.Find("AnswerPanel").GetComponentInChildren<Text>().text = answer;

        }
        else
        {
            GameObject.Find("AnswerPanel").GetComponentInChildren<Text>().text = question;

        }
    }


}
