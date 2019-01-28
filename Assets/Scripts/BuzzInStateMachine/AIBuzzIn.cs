using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AIBuzzIn : MonoBehaviour
{
    public QAGameHostController qaghc;

    public bool redBuzzedIn;
    public bool blueBuzzedIn;
    public bool redDisable ;
    public bool blueDisable ;

    public GameObject RedTeamControllerIndicator;
    public GameObject BlueTeamControllerIndicator;

    private Image redImage;
    private Image blueImage;

    public GameObject RedPanel;
    public GameObject BluePanel;

    private Image redPanelImage;
    private Image bluePanelImage;

    public bool IsReady { get; set; }

    // Use this for initialization
    void Start()
    {
        IsReady = false;

        redImage = RedTeamControllerIndicator.GetComponent<Image>();
        blueImage = BlueTeamControllerIndicator.GetComponent<Image>();

        redPanelImage = RedPanel.GetComponent<Image>();
        bluePanelImage = BluePanel.GetComponent<Image>();
    }

    // EnabledRedController()

    // EnableBlueController()

    // DisableRedController()

    // DisableBlueController()

    // bool blueEnabled
    // bool redEnabled

    /*
     * Called when professor clicks on $100 button
     */

    public void disableBuzzes()
    {
        redBuzzedIn = false;
        blueBuzzedIn = false;
        redDisable = true;
        blueDisable = true;

    }

    /*
     * Called by start button
     */

    public void enableBuzzes()
    {
        qaghc.lastPointsButtonClicked = "";
        redBuzzedIn = false;
        blueBuzzedIn = false;
        redDisable = false;
        blueDisable = false;
        Debug.Log("    redDisable    " + redDisable);
        Debug.Log("    blueDisable    " + blueDisable);
    }
     

    public void startRedFlash()
    {
        StartCoroutine("IRedFlash");
    }

    public void stopRedFlash()
    {
        StopCoroutine("IRedFlash");
        redPanelImage.color = Color.red;
    }

    public void startBlueFlash()
    {
        StartCoroutine("IBlueFlash");
    }

    public void stopBlueFlash()
    {
        StopCoroutine("IBlueFlash");
        bluePanelImage.color = Color.blue;
    }

    IEnumerator IRedFlash()
    {

        while(true)
        {
            if (redPanelImage.color == Color.red)
                redPanelImage.color = Color.white;
            else
                redPanelImage.color = Color.red;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator IBlueFlash()
    {

        while (true)
        {
            if (bluePanelImage.color == Color.blue)
                bluePanelImage.color = Color.white;
            else
                bluePanelImage.color = Color.blue;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetJoystickNames().Length == 0)
        {
            redImage.color = Color.red;
            blueImage.color = Color.red;

        }
        else if (Input.GetJoystickNames().Length == 1)
        {
            redImage.color = Color.green;
            blueImage.color = Color.red;
        }
        else
        {
            redImage.color = Color.green;
            blueImage.color = Color.green;
        }

        if (Input.GetButton("redBuzz") && !redDisable)
        {
            redImage.color = Color.red;

            if (blueBuzzedIn)
                redBuzzedIn = false;
            else
                redBuzzedIn = true;

            if (redBuzzedIn)
            {
                startRedFlash();
                redDisable = true;
            }

        }

        if (Input.GetButton("blueBuzz") && !blueDisable)
        {
            blueImage.color = Color.blue;
            if (redBuzzedIn) blueBuzzedIn = false;
            else blueBuzzedIn = true;

            if (blueBuzzedIn)
            {
                startBlueFlash();
                blueDisable = true;

            }
        }

        if(qaghc.lastPointsButtonClicked == "redSubtract" ){
            redBuzzedIn = false;
            redDisable = true;
            stopRedFlash();
        }
        if(qaghc.lastPointsButtonClicked == "blueSubtract" ){
            blueBuzzedIn = false;
            blueDisable = true;
            stopBlueFlash();
          
        }
        if(qaghc.lastPointsButtonClicked == "redAdd" || qaghc.lastPointsButtonClicked == "blueAdd"){
            stopRedFlash();
            stopBlueFlash();
            disableBuzzes();

        }

    }
}
