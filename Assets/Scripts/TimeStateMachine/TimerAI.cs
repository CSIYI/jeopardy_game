using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAI : MonoBehaviour
{
    public AIBuzzIn aibuzzin;
    public int TotalTime { get; set; } //Countdown
    public GameObject AudienceObject { get; private set; }
    public bool IsPlaying { get; set; }

    private Text clockText;

    public GameObject startButton;
    public GameObject pauseButton;
    public GameObject resetButton;


    // Use this for initialization
    void Start()
    {
        AudienceObject = GameObject.Find("GameAudienceScreen");
        clockText = GameObject.Find("ClockText").GetComponent<Text>();
        IsPlaying = false;
        TotalTime = 60;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PauseButtonClick()
    {
        IsPlaying = false;
        aibuzzin.disableBuzzes();
    }

    public void StartButtonClick()
    {
        IsPlaying = true;
        AudienceObject.SendMessage("changePanel", "Question"); //audience screen show quesiton
        aibuzzin.enableBuzzes();

    }



    public void ResetButtonClick()
    {
        IsPlaying = false;
        TotalTime = 60;
        UpdateClockText();
    }

    public void StartCountDown()
    {
        StartCoroutine("ICountDown");
    }

    public void PauseCountDown()
    {
        Debug.Log("PauseCountDown");
        StopCoroutine("ICountDown");
    }

    private IEnumerator ICountDown()
    {

        while (TotalTime >= 0)
        {
            UpdateClockText();
            yield return new WaitForSeconds(1);
            TotalTime--;
        }
    }

    private void UpdateClockText()
    {
        clockText.text = TotalTime.ToString();
        AudienceObject.SendMessage("SetAudienceTime", TotalTime.ToString());
    }
}
