using UnityEngine;
using System.Collections;

public class TutoScript : MonoBehaviour {

    public string buttonBackText = "OK";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        Rect rect = new Rect(Screen.width * 0.85f, Screen.height * 0.83f, Screen.width * 0.10f, Screen.height * 0.1f);
        if (GUI.Button(rect, buttonBackText))
        {
            Application.LoadLevel("Main");
        }
    }
}
