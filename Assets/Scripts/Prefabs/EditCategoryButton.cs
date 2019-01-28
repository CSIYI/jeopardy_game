using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditCategoryButton : MonoBehaviour {

	public JCategory Category { get; set; }

	void Start () {
		ManualUpdate();
	}
	
	public void ManualUpdate () {
	    Text text = gameObject.transform.GetComponentInChildren<Text>();
	    text.text = Category.Category;
	}

    public void OnClick()
    {
        var controller = this.transform.parent.parent.parent.parent.GetComponent<CreateGameController>();
        controller.CurrentEditingCategory = Category;
        controller.CallbackMethod = ManualUpdate;
        controller.CategoryButtonClick();
    }
   
}
