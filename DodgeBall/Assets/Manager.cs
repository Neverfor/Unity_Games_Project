using UnityEngine;
using Assets;

    public class Manager : MonoBehaviour {
        //Gameplay
        public Player Winner = null;
        public bool GameEnded = false;
        public int MaxScore = 10;

        //Ball
        public DodgeBall Ball;

        public static Manager Settings;

        void Start ()
	{ 
		Debug.Log (" score: ");
		foreach (Player player in FindObjectsOfTypeAll(typeof(Player))){
				player.Mesh.text = player.name + " score: " + player.Score;
			}
            if (Settings == null)
                Settings = this;
            else 
                throw new UnityException (
                    "Manager is a SingleTon, and can only have 1 instance. " +
					"To reference this instance, use Manager.settings");
            Instantiate ( 
                Settings.Ball, 
                new Vector3(0,1f,0),
                Quaternion.identity);
        }

        public void IncreaseScore(Player player, int score = 1)
        {
            player.Score += 1;
            player.Mesh.text = player.name + " score: " + player.Score;
            if (player.Score == MaxScore)
            {
                EndGame(player);
            }
        }

		void OnGUI() {
		if (Winner != null)
		if (GUI.Button (new Rect (Screen.width/2-75, Screen.height/2-50, 150, 100), Winner.PlayerName + " Won! \n Click to play again!")) {
			Application.LoadLevel ("Scene2");
				}
			
		}

        public static void EndGame(Player winner)
        {
            Settings.Winner = winner;
			Time.timeScale = 0f;
        }
    }
