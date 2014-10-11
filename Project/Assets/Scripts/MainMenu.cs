using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture background;

    void OnGUI()
    {
        Rect rect = new Rect(Screen.width * 0.25f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f);
        if(GUI.Button(rect, "Jouer"))
        {

        }

        Rect rect2 = new Rect(Screen.width * 0.25f, Screen.height * 0.65f, Screen.width * 0.5f, Screen.height * 0.1f);
        if (GUI.Button(rect2, "Quitter"))
        {
            Application.Quit();
        }
    }
}
