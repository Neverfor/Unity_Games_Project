using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour {
	public FixedJoint ballJoint;
	public string catchBallInput;
    public int ballBreakForce = 350;

	private PlayerPhysics playerPhysics;
	
	public string inputAxisHorizontal;
	public string inputAxisVertical;
	
	public float speed = 10f;
	public float acceleration = 30f;
	
	private float currentSpeedx;
	private float targetSpeedx;
	private float currentSpeedz;
	private float targetSpeedz;
	
	private Vector3 amountToMove;

	void Start() {
		if (inputAxisHorizontal == null || inputAxisVertical == null)
			throw new UnityException("One or more inputs aren't specified");
		playerPhysics = GetComponent<PlayerPhysics>();
	}

	void Update () {
		if (playerPhysics.movementStopped) {
			targetSpeedx = 0f;
			currentSpeedx = 0;
			targetSpeedz = 0f;
			currentSpeedz = 0;
		}
		targetSpeedx = Input.GetAxisRaw (inputAxisHorizontal) * speed;
		targetSpeedz = Input.GetAxisRaw (inputAxisVertical) * speed;
		currentSpeedx = IncrementTowards (currentSpeedx, targetSpeedx, acceleration);
		currentSpeedz = IncrementTowards (currentSpeedz, targetSpeedz, acceleration);
		amountToMove.y = 0;
		amountToMove.x = currentSpeedx;
		amountToMove.z = currentSpeedz;
		playerPhysics.Move (amountToMove * Time.deltaTime);
	}

	private float IncrementTowards(float n, float target, float a){
		if (n == target) {
			return n;
		} 
		else {
			float dir = Mathf.Sign (target-n);
			n += a *Time.deltaTime*dir;
			return (dir==Mathf.Sign (target-n))?n:target;
		}
	}

	void FixedUpdate () {
		if(Input.GetKey(KeyCode.O))
		{
			if (ballJoint)
			{
				var ballBody = ballJoint.connectedBody;
				if(ballBody.gameObject.tag == "ball")
				{
					ballBody.AddForce (playerPhysics.playerDir * 3000 * Time.deltaTime, ForceMode.Impulse);
					Destroy(ballJoint);
					ballJoint = null;
				}
			}
		}
		
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "ball")
		{
			GameObject ball = col.gameObject;
			if(Input.GetKey(KeyCode.L) && ballJoint == null)
			{
				ballJoint = null;
				ballJoint = gameObject.AddComponent<FixedJoint>();
				ballJoint.connectedBody = col.rigidbody;
                ballJoint.breakForce = ballBreakForce;
			}
			else if((GameManager.lastCollidedPlayer != this.gameObject)&& (GameManager.lastCollidedPlayer !=null))
			{
				ScoreManager.AddScoreToPlayer(name);
				GameObject textP1 = GameObject.Find("Player 1 score");
				TextMesh textMeshP1 = textP1.GetComponent<TextMesh>();
				GameObject textP2 = GameObject.Find("Player 2 score");
				TextMesh textMeshP2 = textP2.GetComponent<TextMesh>();

				textMeshP1.text = "P1 score: " + ScoreManager.Player1Score;
				textMeshP2.text = "P2 score: " + ScoreManager.Player2Score;
			}

			GameManager.lastCollidedPlayer = this.gameObject;
		}

		
	}
}
