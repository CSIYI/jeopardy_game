using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseQuestionEditPanel : MonoBehaviour
{

    public Button button;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Close()
    {
        string s = transform.Find("InputField").GetComponent<InputField>().text;

        button.gameObject.transform.Find("AnswerText").GetComponent<Text>().text = s;
        gameObject.SetActive(false);
    }
}
