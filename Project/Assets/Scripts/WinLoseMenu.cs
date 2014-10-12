using UnityEngine;
using System.Collections;

public class WinLoseMenu : MonoBehaviour
{
    public string button2TextWL;

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 0.35f, Screen.height * 0.5f, Screen.width * 0.3f, Screen.height * 0.1f), "Quitter"))
        {
            Application.Quit();
        }
    }
}
