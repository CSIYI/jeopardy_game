using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateGame : MonoBehaviour
{
	public GameObject jeopardy;
	public GameObject doubleJeopardy;
	public GameObject finalJeopardy;

	public void SwitchPanel(string name)
	{
		if (name == "Jeopardy")
		{
			jeopardy.SetActive(true);
			doubleJeopardy.SetActive(false);
			finalJeopardy.SetActive(false);
		}
		else if (name == "DoubleJeopardy")
		{
			jeopardy.SetActive(false);
			doubleJeopardy.SetActive(true);
			finalJeopardy.SetActive(false);
		}
		else if (name == "FinalJeopardy")
		{
			jeopardy.SetActive(false);
			doubleJeopardy.SetActive(false);
			finalJeopardy.SetActive(true);
		}
	}
}
