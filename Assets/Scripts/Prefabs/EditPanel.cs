using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPanel : MonoBehaviour
{
	public GameObject EditPanelPrefab;
    public GameObject EditCategoryButtonPrefab;
    public GameObject EditQuestionButtonPrefab;
    public bool IsDoublePanel;

	// Use this for initialization
	void Start () {
		// Create Question Panel
		for (int i = 0; i < GameData.Column; i++)
		{
			var newPanel = Instantiate(EditPanelPrefab);
			newPanel.name = "Panel" + i;
		    
		    var categoryPanel = newPanel.transform.GetChild(0).transform;
		    var questionPanel = newPanel.transform.GetChild(1).transform;
	    
		    // Create Category Panel
		    var newCategory = Instantiate(EditCategoryButtonPrefab);
		    newCategory.transform.SetParent(categoryPanel, false);
		    newCategory.GetComponent<EditCategoryButton>().Category =
		        IsDoublePanel ? GameData.DoubleCategory[i] : GameData.Category[i];

		    // Create Question Panel
		    for (int j = 0; j < GameData.Row; j++)
		    {
		        var newQuestion = Instantiate(EditQuestionButtonPrefab);
		        newQuestion.name = "Question" + j;
		        newQuestion.GetComponent<EditQuestionButton>().QuestionInfo = 
		            IsDoublePanel ? GameData.DoubleQuestion[i][j] : GameData.Question[i][j];
		        
		        newQuestion.transform.SetParent(questionPanel, false);
		    }
		    
			newPanel.transform.SetParent(this.transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
