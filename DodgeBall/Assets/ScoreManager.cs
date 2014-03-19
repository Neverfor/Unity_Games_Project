using UnityEngine;
using System.Collections;

public static class ScoreManager {

	//Here scores are calculated and returned

	public static int Player1Score = 0;
	public static int Player2Score = 0;

	public static void ResetScores()
	{
		Player1Score = 0;
		Player2Score = 0;
		GameManager.winner = null;
	}

	public static void AddScoreToPlayer(string playerName)
	{
		if (playerName.Equals ("Player 1")) 
			Player1Score = Player1Score+1;

		else if (playerName.Equals ("Player 2")) 
			Player2Score = Player2Score+1;

		if (Player1Score == 6)
			GameManager.EndGame ("Player 1");

		else if (Player2Score == 6)
			GameManager.EndGame ("Player 2");
	}

	public static void SubstractScoreFromPlayer (string playerName)
	{
		if (playerName.Equals ("Player1")) 
		{
			Player1Score = Player1Score-1;
		}
		if (playerName.Equals ("Player2")) 
		{
			Player2Score = Player2Score-1;
		}
	}

	public static int CalculateTeam1Score()
	{
		int team1Score = Player1Score;
		return team1Score;
	}

	public static int CalculateTeam2Score()
	{
		int team2Score = Player2Score;
		return team2Score;
	}

	public static string ReturnResultScore()
	{
		string result = "Team 1: " + CalculateTeam1Score() + ";\n" + 
						"Team 2: " + CalculateTeam2Score() + ".";
		Debug.Log("<color=red>Team 1: </color>" + CalculateTeam1Score().ToString());
		Debug.Log("<color=red>Team 2: </color>" + CalculateTeam2Score().ToString());
		return result;
	}
}
