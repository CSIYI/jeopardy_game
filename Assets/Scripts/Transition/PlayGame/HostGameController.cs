using System.Collections;
    //question panel
    private GameObject jeopardyObject;


        jeopardyObject.SetActive(true);
        selectTeamObject.SetActive(false);

        AudienceData.GetInstance().SetTeamInformation(GameData.RedTeam, GameData.BlueTeam);
            GameObject.Find("Category" + i.ToString()).GetComponentInChildren<Text>().text = GameData.Category[i].Category;
        }
        for (int i = 0; i < count; i++)

    IEnumerator UpdateAudienceScreen()
        UpdateTeamName();


    // Update is called once per frame
    void Update() {
        string rowIndex = currentButtonName.Substring((currentButtonName.Length) - 1, 1);

            isDaily = GameData.DoubleQuestion[line][row].isDouble;
        AudienceData.GetInstance().SetAddBlueScore(addButtonScore);
        aibuzzin.disableBuzzes();

        // audience button disppears
        if (index != "")

            AudienceData.GetInstance().SetBlueTeamScore(currentBlueScore);

    public void ExitScoreScreenButtonClick()
        GameObject.Find("Team1ScoreButton").GetComponentInChildren<Text>().text = AudienceData.GetInstance().GetRedScore().ToString();
        GameObject.Find("Team2ScoreButton").GetComponentInChildren<Text>().text = AudienceData.GetInstance().GetBlueScore().ToString();
        NotifyAudience();