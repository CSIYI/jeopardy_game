using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChooseTeamController : MonoBehaviour {

    private int temporaryRedIndex;
    private int temporaryBlueIndex;
    private List<string> redTeams;
    private List<string> blueTeams;
    private int currentRedIndex;
    private int currentBlueIndex;

    private string currentButtonName;

    private GameObject gameHostObject;

    bool isFirstShowScreen = true;

    // Use this for initialization
    void Start () {
        gameHostObject = GameObject.Find("GameHostScreen");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnEnable()
    {
        if(isFirstShowScreen)
        {
            isFirstShowScreen = false;
            return;
        }
        if (redTeams == null || blueTeams == null)
        {
            redTeams = AudienceData.GetInstance().GetRedTeams();
            blueTeams = AudienceData.GetInstance().GetBlueTeams();
            currentRedIndex = AudienceData.GetInstance().GetCurrentRedIndex();
            currentBlueIndex = AudienceData.GetInstance().GetCurrentBlueIndex();
        }


        for (int i = 0; i < redTeams.Count; i++)
        {
            string buttonName = "RedTeamButton" + i.ToString();
            GameObject button = GameObject.Find(buttonName);

            if (i == currentRedIndex)
            {
                changeTeamButtonColor(button, Color.black, Color.white);
            }
            else
            {
                changeTeamButtonColor(button, Color.white, Color.black);
            }
            button.GetComponentInChildren<Text>().text = redTeams[i];
        }

        temporaryRedIndex = currentRedIndex;

        for (int i = 0; i < blueTeams.Count; i++)
        {
            string buttonName = "BlueTeamButton" + i.ToString();
            GameObject button = GameObject.Find(buttonName);

            if (i == currentBlueIndex)
            {
                changeTeamButtonColor(button, Color.black, Color.white);
            }
            else
            {
                changeTeamButtonColor(button, Color.white, Color.black);
            }
            button.GetComponentInChildren<Text>().text = redTeams[i];
        }

        temporaryBlueIndex = currentBlueIndex;
    }

    //team pannel

    public void saveTeamButtonClick()
    {
        AudienceData.GetInstance().SetTeamsIndex(temporaryRedIndex, temporaryBlueIndex);
        gameHostObject.SendMessage("UpdateTeamName");
        gameObject.SetActive(false);

    }

    public void ExitTeamButtonClick()
    {
        gameObject.SetActive(false);
    }

    public void SelectOneRedTeamButtonClick()
    {
        currentButtonName = EventSystem.current.currentSelectedGameObject.name;
        string indexString = currentButtonName.Substring((currentButtonName.Length) - 1, 1);
        temporaryRedIndex = System.Int32.Parse(indexString);

        for (int i = 0; i < redTeams.Count; i++)
        {
            if (i == temporaryRedIndex)
            {
                GameObject button = EventSystem.current.currentSelectedGameObject;
                changeTeamButtonColor(button, Color.black, Color.white);
            }
            else
            {
                string buttonName = "RedTeamButton" + i.ToString();
                GameObject button = GameObject.Find(buttonName);
                changeTeamButtonColor(button, Color.white, Color.black);
            }
        }

    }

    public void SelectOneBlueTeamButtonClick()
    {
        currentButtonName = EventSystem.current.currentSelectedGameObject.name;
        string indexString = currentButtonName.Substring((currentButtonName.Length) - 1, 1);
        temporaryBlueIndex = System.Int32.Parse(indexString);

        for (int i = 0; i < blueTeams.Count; i++)
        {
            if (i == temporaryBlueIndex)
            {
                GameObject button = EventSystem.current.currentSelectedGameObject;
                changeTeamButtonColor(button, Color.black, Color.white);
            }
            else
            {
                string buttonName = "BlueTeamButton" + i.ToString();
                GameObject button = GameObject.Find(buttonName);
                changeTeamButtonColor(button, Color.white, Color.black);
            }
        }
    }

    private void changeTeamButtonColor(GameObject button, Color buttonColor, Color textColor)
    {
        ColorBlock cb = button.GetComponentInChildren<Button>().colors;
        cb.normalColor = cb.highlightedColor = buttonColor;
        button.GetComponentInChildren<Button>().colors = cb;
        button.GetComponentInChildren<Text>().color = textColor;
    }
}
