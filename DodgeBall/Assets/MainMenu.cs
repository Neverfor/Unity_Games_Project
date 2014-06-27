using UnityEngine;
using System.Collections;
using System;

public class MainMenu : MonoBehaviour 
{
    public bool gameStarted = false;
    public bool optionsLoaded = false;
    public string typedScore = "";
    public int tryToParse = 0;


    void Start()
    {
        if (!gameStarted)
        {
            SwitchCameraToMenu();
        }
    }

    void Update()
    {
        if (gameStarted)
        {
            SwitchCameraToMain();
        }
    }
    public void OnGUI()
    {
        if (!gameStarted)
        {
            if (!optionsLoaded)
            {
                GUI.Window(0, new Rect(Screen.width / 2 - 210, Screen.height / 2 - 125, 420, 250), GameMenuWindow, "Game Menu");
            }

            if (optionsLoaded)
            {
                GUI.Window(1, new Rect(Screen.width / 2 - 210, Screen.height / 2 - 125, 420, 250), GameOptionsWindow, "Game Options");
            }
        }
        if(gameStarted)
        {
            //Draw nothing
        }
    }


    void GameMenuWindow(int windowId)
    {
        if (GUI.Button(new Rect(105, 50, 210, 30), "Options"))
        {
            optionsLoaded = true;
        }

        if (GUI.Button(new Rect(105, 100, 210, 30), "Play!"))
        {
            //Application.LoadLevel("Scene2");
            gameStarted = true;
        }

        if (GUI.Button(new Rect(105, 150, 210, 30), "Dev Page"))
        {
            Application.OpenURL("https://github.com/Neverfor/Unity_Games_Project/");
        }

        if (GUI.Button(new Rect(105, 200, 210, 30), "Quit"))
        {
            Application.Quit();
        }
    }

    void GameOptionsWindow(int windowId)
    {
        if (Manager.Settings.seeTheBallHolder)
        {
            if(GUI.Button(new Rect(105, 50, 210, 30), "Do not show ball holder"))
            {
                Manager.Settings.seeTheBallHolder = false;
            }
        }

        if (!Manager.Settings.seeTheBallHolder)
        {
            if (GUI.Button(new Rect(105, 50, 210, 30), "Show the ball holder"))
            {
                Manager.Settings.seeTheBallHolder = true;
            }
        }

        typedScore = GUI.TextField(new Rect(105, 100, 210, 30), typedScore);
        if (GUI.Button(new Rect(105, 150, 210, 30), "Update maximum score"))
        {
            if (int.TryParse(typedScore, out tryToParse))
            {
                Manager.Settings.MaxScore = Int32.Parse(typedScore);
            }
        }


        if (GUI.Button(new Rect(105, 200, 210, 30), "Main Menu"))
        {
            optionsLoaded = false;
        }    
    }

    public void SwitchCameraToMain()
    {
        GameObject.Find("Main Camera").camera.enabled = true;
        GameObject.Find("Menu Camera").camera.enabled = false;
    }
    
    public void SwitchCameraToMenu()
    {
        GameObject.Find("Main Camera").camera.enabled = false;
        GameObject.Find("Menu Camera").camera.enabled = true;
    }
}
