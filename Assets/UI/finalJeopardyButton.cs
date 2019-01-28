using UnityEngine.UI;
using UnityEngine;

public class finalJeopardyMUsic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button b = GetComponent<Button>();
        AudioSource finalJeopardyAudio = GetComponent<AudioSource>();
        b.onClick.AddListener(delegate () { finalJeopardyAudio.Play(); });
    }
	
	
}
