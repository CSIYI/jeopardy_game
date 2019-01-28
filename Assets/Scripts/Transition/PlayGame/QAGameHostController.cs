using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QAGameHostController : MonoBehaviour {

    public string lastPointsButtonClicked { get; set; }
    public TimerAI timerAI;
    public AIBuzzIn aIBuzzIn;

    private GameObject gameHostObject;
    private GameObject audienceObject;
    private GameObject wagerObject;
    private GameObject qaGameAudienceObject;

    private int currentAddRedScore;
    private int currentAddBlueScore;

    bool isRed;

    bool isFirstShowScreen = true;


    // Use this for initialization
    void Start () {
        gameHostObject = GameObject.Find("GameHostScreen");
        audienceObject = GameObject.Find("GameAudienceScreen");
        wagerObject = GameObject.Find("SetWagerOverlay");
        qaGameAudienceObject = GameObject.Find("QAGameAudienceScreen");
    }

    // Update is called once per frame
    void Update () {
	
	}

    private void OnEnable()
    {
        if (isFirstShowScreen)
        {
            isFirstShowScreen = false;
            return;
        }

        AudienceData audienceData = AudienceData.GetInstance();
        currentAddRedScore = audienceData.GetAddRedScore();
        currentAddBlueScore = audienceData.GetAddBlueScore();
        //set score and team
        GameObject.Find("RedAddButton").GetComponentInChildren<Text>().text = "+" + currentAddRedScore.ToString();
        GameObject.Find("RedSubtractButton").GetComponentInChildren<Text>().text = "-" + currentAddRedScore.ToString();
        GameObject.Find("BlueAddButton").GetComponentInChildren<Text>().text = "+" + currentAddBlueScore.ToString();
        GameObject.Find("BlueSubtractButton").GetComponentInChildren<Text>().text = "-" + currentAddBlueScore.ToString();
        GameObject.Find("RedText").GetComponentInChildren<Text>().text = audienceData.GetRedTeamName();
        GameObject.Find("BlueText").GetComponentInChildren<Text>().text = audienceData.GetBlueTeamName();

        string question, answer;
        int line = audienceData.GetQuestionLine();
        int row = audienceData.GetQuestionRow();
        if(audienceData.GetQuestionType() == 0)
        {
            question = GameData.Question[line][row].Question;
            answer = GameData.Question[line][row].Answer;
        }
        else if(audienceData.GetQuestionType() == 1)
        {
            question = GameData.DoubleQuestion[line][row].Question;
            answer = GameData.DoubleQuestion[line][row].Answer;
        }
        else
        {
            question = GameData.FinalQuestion.Question;
            answer = GameData.FinalQuestion.Answer;
        }

        GameObject.Find("QuestionButton").GetComponentInChildren<Text>().text = question;
        GameObject.Find("AnswerButton").GetComponentInChildren<Text>().text = answer;
    }

    public void ExitQAHostButtonClick()
    {
        gameObject.SetActive(false);
        audienceObject.SendMessage("changePanel", "ExitQuestion");
        timerAI.ResetButtonClick();
        aIBuzzIn.disableBuzzes();

    }

    public void RedAddScoreButtonClick()
    {
        lastPointsButtonClicked = "redAdd";

        //music
        FindObjectOfType<AudioManager>().Play("Applaud");

        int currentRedScore = AudienceData.GetInstance().GetRedScore();
        currentRedScore += currentAddRedScore;
        AudienceData.GetInstance().SetRedTeamScore(currentRedScore);

        gameHostObject.SendMessage("UpdateTeamScore");
    }

    public void RedSubtractButtonClick()
    {
        lastPointsButtonClicked = "redSubtract";

        //music
        FindObjectOfType<AudioManager>().Play("Sad");

        int currentRedScore = AudienceData.GetInstance().GetRedScore();
        currentRedScore -= currentAddRedScore;
        AudienceData.GetInstance().SetRedTeamScore(currentRedScore);

        gameHostObject.SendMessage("UpdateTeamScore");
    }



    public void BlueAddScoreButtonClick()
    {
        lastPointsButtonClicked = "blueAdd";

        //music
        FindObjectOfType<AudioManager>().Play("Applaud");

        int currentBlueScore = AudienceData.GetInstance().GetBlueScore();

        currentBlueScore += currentAddBlueScore;
        AudienceData.GetInstance().SetBlueTeamScore(currentBlueScore);


        gameHostObject.SendMessage("UpdateTeamScore");
    }

    public void BlueSubtractButtonClick()

    {

        lastPointsButtonClicked = "blueSubtract";

        //music
        FindObjectOfType<AudioManager>().Play("Sad");

        int currentBlueScore = AudienceData.GetInstance().GetBlueScore();

        currentBlueScore -= currentAddBlueScore;
        AudienceData.GetInstance().SetBlueTeamScore(currentBlueScore);

        gameHostObject.SendMessage("UpdateTeamScore");
    }

    public void RedWagerButtonClick()
    {
        isRed = true;
        wagerObject.SetActive(true);
        InputField wagerField = wagerObject.GetComponentInChildren<InputField>();
        wagerField.text = currentAddRedScore.ToString();


    }

    public void BlueWagerButtonClick()
    {
        isRed = false;
        wagerObject.SetActive(true);
        InputField wagerField = wagerObject.GetComponentInChildren<InputField>();
        wagerField.text = currentAddBlueScore.ToString();
    }

    //wager pannel

    public void ExitWagerButtonClick()
    {
        wagerObject.SetActive(false);
    }

    public void SetWagerButtonClick()
    {
        InputField wagerField = wagerObject.GetComponentInChildren<InputField>();

        if (isRed)
        {
            currentAddRedScore = System.Int32.Parse(wagerField.text);//set score
            GameObject.Find("RedAddButton").GetComponentInChildren<Text>().text = "+" + currentAddRedScore.ToString();
            GameObject.Find("RedSubtractButton").GetComponentInChildren<Text>().text = "-" + currentAddRedScore.ToString();
        }
        else
        {
            currentAddBlueScore = System.Int32.Parse(wagerField.text);//set score
            GameObject.Find("BlueAddButton").GetComponentInChildren<Text>().text = "+" + currentAddBlueScore.ToString();
            GameObject.Find("BlueSubtractButton").GetComponentInChildren<Text>().text = "-" + currentAddBlueScore.ToString();
        }

        wagerObject.SetActive(false);
    }

    public void AnswerQuestionButtonClick()
    {
        ////display either question or answer on the student view
        //public void ChangeDisplay()
        //{
        bool isAnswer;
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        if(obj.name == "AnswerButton")
        {
            isAnswer = true;
        }
        else
        {
            isAnswer = false;
        }
        //    GameObject object1 = obj.transform.GetChild(0).gameObject;
        //    Debug.Log(object1.GetComponent<Text>().text);

        //    displayPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = object1.GetComponent<Text>().text;

        //}

        qaGameAudienceObject.SendMessage("UpdateContent", isAnswer);
    }

}
