using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateGamePanelSwitch : MonoBehaviour
{
    private string[] panelList =
    {
        "Teams", "Jeopardy", "DoubleJeopardy", "FinalJeopardy" 
    };

    private string[] gamePanelList =
    {
        "CategoryEditPanel", "QuestionEditPanel"
    };
    
    private Dictionary<string, GameObject> panels;
    private Dictionary<string, Button> panelButton;
    private Dictionary<string, GameObject> gamePanels;
    
    public Button teamsButton;
    public Button jeopardyButton;
    public Button doubleJeopardyButton;
    public Button finalJeopardyButton;

    void Start()
    {
        panels = new Dictionary<string, GameObject>();
        gamePanels = new Dictionary<string, GameObject>();
        panelButton = new Dictionary<string, Button>();
        foreach (var panelName in panelList)
        {
            GameObject panel = GameObject.Find(panelName+"Panel");
            panels.Add(panelName, panel);
            
            Button button = GameObject.Find(panelName+"Button").GetComponent<Button>();
            panelButton.Add(panelName,button);
            panel.transform.position = new Vector3(-512,-384,0);
            panel.SetActive(false);
        }
        panels["Teams"].SetActive(true);
       
        foreach (var panelName in gamePanelList)
        {
            GameObject panel = GameObject.Find(panelName);
            gamePanels.Add(panelName, panel);
            panel.transform.position = new Vector3(0, -1000, 0);
        }
    }

    private void ChangeButtonColorAndText(Button button, Color buttonColor, Color textColor)
    {
        ColorBlock cb = button.GetComponentInChildren<Button>().colors;
        cb.normalColor = cb.highlightedColor = buttonColor;
        button.GetComponentInChildren<Button>().colors = cb;
        button.GetComponentInChildren<Text>().color = textColor;
    }

    private void SetActive(string name)
    {
        foreach (var panel in panelList)
        {
            panels[panel].SetActive(false);
            ChangeButtonColorAndText(panelButton[panel], Color.white, Color.black);
        }
        panels[name].SetActive(true);
        ChangeButtonColorAndText(panelButton[name], Color.white, Color.black);
        
    }
    
    public void SwitchToTeams()
    {  
        SetActive("Teams");
    }

    public void SwitchToJeopardy()
    {
        SetActive("Jeopardy");
    }

    public void SwitchToDoubleJeopardy()
    {
        SetActive("DoubleJeopardy");
    }

    public void SwitchToFinalJeopardy()
    {
        SetActive("FinalJeopardy");
    }

    public void OpenEditQuestionPanel()
    {
        gamePanels["QuestionEditPanel"].transform.position = new Vector3(0,0,0);
    }
    
    public void OpenEditCategoryPanel()
    {
        gamePanels["CategoryEditPanel"].transform.position = new Vector3(0,0,0);
    }
    
    public void CloseEditQuestionPanel()
    {
        gamePanels["QuestionEditPanel"].transform.position = new Vector3(0,-1000,0);
    }
    
    public void CloseEditCategoryPanel()
    {
        gamePanels["CategoryEditPanel"].transform.position = new Vector3(0,-1000,0);
    }
}
