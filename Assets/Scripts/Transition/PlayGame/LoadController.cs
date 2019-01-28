using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadController : MonoBehaviour
{

    public GameObject buttonObject;
    private GameObject loadGamesPanel;

    private int buttonCount;
    private int currentGame = 0;
    private GameObject[] allButtons;
    private string currentButtonName;

    void Start()
    {

        Transform temp_transform = gameObject.GetComponent<Transform>();
        temp_transform.position = new Vector3(0f, temp_transform.position.y, temp_transform.position.z);

        buttonCount = 3;
        allButtons = new GameObject[buttonCount];

        loadGamesPanel = GameObject.Find("LoadGamesPanel");

        for (int i = 0; i < buttonCount; i++)
        {
            GameObject newButton = Instantiate(buttonObject);
            newButton.GetComponentInChildren<Text>().text = @"PlayGame0";
            newButton.transform.SetParent(loadGamesPanel.transform, false);

            if (i != 0)
            {
                GameObject tempObjetct = allButtons[i - 1];
                newButton.GetComponent<Transform>().position = new Vector3(
                                tempObjetct.transform.position.x, tempObjetct.transform.position.y - 150, tempObjetct.transform.position.z);
            }

            newButton.GetComponentInChildren<Text>().text = @"PlayGame" + i.ToString();
            newButton.name = "button" + i.ToString();
            newButton.SetActive(true);
            allButtons[i] = newButton;
        }


        for (int i = 0; i < buttonCount; i++)
        {
            GameObject button = allButtons[i];

            if (i == currentGame)
            {
                changeTeamButtonColor(button, Color.black, Color.white);
            }
            else
            {
                changeTeamButtonColor(button, Color.white, Color.black);
            }
        }

    }

    public void LoadButtonClick()
    {
        //handle data

        //get current Index

        gameObject.SetActive(false);
    }

    public void GameButtonClick()
    {
        GameObject clickButton = EventSystem.current.currentSelectedGameObject;

        string indexString = clickButton.name.Substring((clickButton.name.Length) - 1, 1);
        int index = System.Int32.Parse(indexString);
        currentGame = index;

        for (int i = 0; i < buttonCount; i++)
        {
            GameObject button = allButtons[i];

            if (i == currentGame)
            {
                changeTeamButtonColor(button, Color.black, Color.white);
            }
            else
            {
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
