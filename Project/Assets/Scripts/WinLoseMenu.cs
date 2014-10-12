using UnityEngine;
using System.Collections;

public class WinLoseMenu : MonoBehaviour
{
    public string button2TextWL;

    void OnGUI()
    {
        Rect rect2 = new Rect(Screen.width * 0.35f, Screen.height * 0.65f, Screen.width * 0.3f, Screen.height * 0.1f);
        if (GUI.Button(rect2, button2TextWL))
        {
            Application.Quit();
        }
    }
}
