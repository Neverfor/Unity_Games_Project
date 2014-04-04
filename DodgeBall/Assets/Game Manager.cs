using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Game variables are declared in this class

	//Gameplay
	public static bool gamePuased = false;
	public static Time pausedAt; 
	public static string winner;

	//Ball and players
	public static float normalBallSpeed = 5.0F;
	public static float maximumBallMagnitude = 18000.0F;
	public static GameObject lastCollidedPlayer = null;
    public static GameObject currentHolder = null;
    public static Vector3 ballStartingPosition = new Vector3(0, 1.48F, 0);
    public static float ballPossesionTime = 0;


	//Players 1-6
	public static float player1Speed = 100.00F;
	public static float player2Speed = 100.00F;
	public static float player3Speed = 100.00F;
	public static float player4Speed = 100.00F;
	public static float player5Speed = 100.00F;
	public static float player6Speed = 100.00F;

	//Map general properties
	public static float mapGravityStrength = 1.0F; 
	public static float mapWindStrength = 2.0F;
	public static float mapSlideStrength = 0.0F;


	//Map specific properties


	//Methods
	public static void ResetAllProperties ()
	{
		player1Speed = 100.00F;
		player2Speed = 100.00F;
		player3Speed = 100.00F;
		player4Speed = 100.00F;
		player5Speed = 100.00F;
		player6Speed = 100.00F;

		mapGravityStrength = 1.0F; 
		mapWindStrength = 2.0F;
		mapSlideStrength = 0.0F;
	}

	public static void EndGame(string winner)
	{
		GameManager.winner = winner;
		Application.LoadLevel ("Highscores");
	}
	
}
