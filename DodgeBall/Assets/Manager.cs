using UnityEngine;
using Assets;

    public class Manager : MonoBehaviour {
        //Gameplay
        public Player Winner = null;
        public bool GameEnded = false;
        public int MaxScore = 5;
        public bool seeTheBallHolder = false;

        //Ball
        public DodgeBall Ball;

        public static Manager Settings;

        void Start ()
		{ 
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
		        new Vector3(0,1.1f,0),
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
		if (Winner == null)
						return;
		if (GUI.Button (new Rect (Screen.width/2-75, Screen.height/2-50, 150, 100), Winner.PlayerName + " Won! \n Click to play again!")) {
			Application.LoadLevel ("Scene2");
				}
		}

        public static void EndGame(Player winner)
        {
            Settings.Winner = winner;
			Time.timeScale = 0f;
        }

        void Update()
        {
            if (seeTheBallHolder)
            {
                /*
                var p1 = GameObject.FindGameObjectWithTag("Player1");
                var p2 = GameObject.Find("Player2");
                if ("p1 heeft de bal".Equals("player 1 has the ball"))
                {
                    GameObject.Find("ArrowP1").renderer.enabled = true;
                    GameObject.Find("ArrowP2").renderer.enabled = false;
                }
                if ("p2 heeft de bal".Equals("player 2 has the ball"))
                {
                    GameObject.Find("ArrowP1").renderer.enabled = false;
                    GameObject.Find("ArrowP2").renderer.enabled = true;
                }
                 * */
            }
            else
            {
                GameObject.Find("ArrowP1").renderer.enabled = false;
                GameObject.Find("ArrowP2").renderer.enabled = false;
            }
          
        }
    }
