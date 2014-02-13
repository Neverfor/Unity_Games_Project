using UnityEngine;
using System.Collections;

public class Score 
{
	public static int score = 0;

	public static void AddPoints(int points)
	{
		score = score + points;
	}
}
