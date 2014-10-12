using UnityEngine;
using System.Collections;

public class GrilleSelector : MonoBehaviour {

    string nombreCase;

	// Use this for initialization
	void Start () {

        nombreCase = "";
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void OnGUI()
    {
        nombreCase = GUI.TextField(new Rect(Screen.width * 0.47f, Screen.height * 0.5f, Screen.width * 0.05f, Screen.height * 0.05f), nombreCase, 2);

        if (GUI.Button(new Rect(Screen.width * 0.47f, Screen.height * 0.6f, Screen.width * 0.05f, Screen.height * 0.05f), "Ok"))
        {
            int n;
            if (int.TryParse(nombreCase, out n) && n > 10)
            {
                if(n < 10)
                {
                    n = 10;
                }
                MapGenerator.width = n;
                MapGenerator.height = n;
                Application.LoadLevel("Tuto");
            }
        }
    }
}
