using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture background;
    public string button1Text;
    public string button2Text;
    public string button3Text = "Tutoriel";

    void OnGUI()
    {
        if(background)
        {
            GUI.DrawTexture(new Rect((Screen.width - background.width) / 2, (Screen.height - background.height) / 2, background.width, background.height), background);
        }

        Rect rect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.3f, Screen.height * 0.1f);
        if (GUI.Button(rect, button1Text))
        {
            Application.LoadLevel("Main");
        }

        Rect rect3 = new Rect(Screen.width * 0.35f, Screen.height * 0.60f, Screen.width * 0.3f, Screen.height * 0.1f);
        if (GUI.Button(rect3, button3Text))
        {
            Application.LoadLevel("Tuto");
        }

        Rect rect2 = new Rect(Screen.width * 0.35f, Screen.height * 0.75f, Screen.width * 0.3f, Screen.height * 0.1f);
        if (GUI.Button(rect2, button2Text))
        {
            Application.Quit();
        }
    }
}
