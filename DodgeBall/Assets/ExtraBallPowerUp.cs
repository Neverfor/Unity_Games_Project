using UnityEngine;
using System.Collections;

namespace Assets 
{
	public class ExtraBallPowerUp : PowerUp 
	{
		#region implemented abstract members of PowerUp

		public override void Buff (GameObject toBuffPlayer)
		{
			toBuffPlayer.GetComponent<Player>().SetBallControl();
		}

		public override void DeBuff (GameObject toDebuffPlayer)
		{
			//do nothing
		}

		#endregion
	}
}