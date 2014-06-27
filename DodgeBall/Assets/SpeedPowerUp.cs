using UnityEngine;
using System.Collections;

namespace Assets 
{
	public class SpeedPowerUp : PowerUp 
	{

		#region implemented abstract members of PowerUp
		public override void Buff(GameObject toBuffPlayer)
		{
			if(toBuffPlayer.GetComponent<Player>().Speed < maxBuffValue)
			{
				toBuffPlayer.GetComponent<Player>().Speed *= 2;
			}		
		}

		public override void DeBuff (GameObject toDebuffPlayer)
		{
			toDebuffPlayer.GetComponent<Player>().Speed /= 2;
		}
		#endregion
	}
}