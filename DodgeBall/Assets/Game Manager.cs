using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Game variables are declared in this class

	//Gameplay
	public static bool gamePuased = false;
	public static Time pausedAt; 

	//Ball
	public static float normalBallSpeed = 5.0F;
	public static float maximumBallMagnitude = 18000.0F;
	public static string lastCollidedObjectName = "None";


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

	//This method checks if the current collider is the same as the last one
	//If it is not, than it will overwrite the lastCollidedObject field
	public static bool IsColliderWithTheBallTheSameAsTheLastOne(string colliderName)
	{
		if (!(lastCollidedObjectName.Equals (colliderName))) 
		{
			lastCollidedObjectName = colliderName;
			Debug.Log ("The colliding object names are differnt.");
			Debug.Log ("Updated lastColliderObjectName=" + lastCollidedObjectName);
			return false;

		} 

		else 
		{
			Debug.Log ("Objects names are the same.");
			return true;
		}
	}
	
}
