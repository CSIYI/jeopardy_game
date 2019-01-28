using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{
    public GameObject RedTeamControllerIndicator;
    public GameObject BlueTeamControllerIndicator;

    private Image redImage;
    private Image blueImage;

    public GameObject RedPanel;
    public GameObject BluePanel;

    private Image redPanelImage;
    private Image bluePanelImage;

    // Use this for initialization
    void Start ()
    {
        redImage = RedTeamControllerIndicator.GetComponent<Image>();
        blueImage = BlueTeamControllerIndicator.GetComponent<Image>();

        redPanelImage = RedPanel.GetComponent<Image>();
        bluePanelImage = BluePanel.GetComponent<Image>();
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

        if (Input.GetButton("redBuzz"))
        {
            redImage.color = Color.blue;
        }

        if (Input.GetButton("blueBuzz"))
        {
            blueImage.color = Color.blue;
        }
    }
}
