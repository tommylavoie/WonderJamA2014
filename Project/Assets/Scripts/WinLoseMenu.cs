using UnityEngine;
using System.Collections;

public class WinLoseMenu : MonoBehaviour
{
    public string button2TextWL;

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.3f, Screen.height * 0.1f), "Rejouer"))
        {
			TileManager.getInstance().resetTiles();
            Application.LoadLevel("Main");
        }
        if (GUI.Button(new Rect(Screen.width * 0.35f, Screen.height * 0.65f, Screen.width * 0.3f, Screen.height * 0.1f), "Quitter"))
        {
            Application.Quit();
        }
    }
}
