using UnityEngine;
using System.Collections;

public static class ScoreManager {

	//Here scores are calculated and returned

	public static int Player1Score = 0;
	public static int Player2Score = 0;
	public static int Player3Score = 0;
	public static int Player4Score = 0;
	public static int Player5Score = 0;
	public static int Player6Score = 0;


	public static void ResetScores()
	{
		Player1Score = 0;
		Player2Score = 0;
		Player3Score = 0;
		Player4Score = 0;
		Player5Score = 0;
		Player6Score = 0;
	}

	public static void AddScoreToPlayer(string playerName)
	{
		if (playerName.Equals ("Player1")) 
		{
			Player1Score = Player1Score+1;
		}
		if (playerName.Equals ("Player2")) 
		{
			Player2Score = Player2Score+1;
		}
		if (playerName.Equals ("Player3")) 
		{
			Player3Score = Player3Score+1;
		}
		if (playerName.Equals ("Player4")) 
		{
			Player4Score = Player4Score+1;
		}
		if (playerName.Equals ("Player5")) 
		{
			Player5Score = Player5Score+1;
		}
		if (playerName.Equals ("Player6")) 
		{
			Player6Score = Player6Score+1;
		}

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
		if (playerName.Equals ("Player3")) 
		{
			Player3Score = Player3Score-1;
		}
		if (playerName.Equals ("Player4")) 
		{
			Player4Score = Player4Score-1;
		}
		if (playerName.Equals ("Player5")) 
		{
			Player5Score = Player5Score-1;
		}
		if (playerName.Equals ("Player6")) 
		{
			Player6Score = Player6Score-1;
		}
	}

	public static int CalculateTeam1Score()
	{
		int team1Score = Player1Score + Player3Score + Player5Score;
		return team1Score;
	}

	public static int CalculateTeam2Score()
	{
		int team2Score = Player2Score + Player4Score + Player6Score;
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
