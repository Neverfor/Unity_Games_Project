using UnityEngine;
using System.Collections;

public class Highscores : MonoBehaviour {


	public void OnLevelWasLoaded(int lvl)
	{
		OnGUI ();
	}
	public void OnGUI() 
	{
		if(!string.IsNullOrEmpty(GameManager.winner))
			GUI.Button(new Rect( 200, 100, 200, 20), GameManager.winner + " won the game");

		if (GUI.Button (new Rect (200, 130, 200, 20), "Try Lost Island Map!")) 
		{
			Application.LoadLevel("Scene2");
			ScoreManager.ResetScores();
		}

        if (GUI.Button(new Rect(200, 160, 200, 20), "Try Space Game!"))
        {
            Application.LoadLevel("Scene3");
            ScoreManager.ResetScores();
        }
	}

}
