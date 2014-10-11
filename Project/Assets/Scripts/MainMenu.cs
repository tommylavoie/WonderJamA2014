using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture background;

    void OnGUI()
    {
        Rect rect = new Rect(Screen.width * 0.5f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f);
        if(GUI.Button(rect, "Jouer"))
        {

        }
    }
}
