using UnityEngine;
using System.Collections;

public enum roleState
{
	SEEK,
	RUNTOPLAYER,
	ESCAPE,
}

public class EnemyAI : MonoBehaviour
{
	public GameObject player;
	public Transform mainCamera;

	public float jumpForce;
	public float speed;

	private float maxSpeed = 15f;

	private bool grounded = true;
	private bool isFaceRight = true;
	private bool inputHorizontal = false;
	private bool inputJump = false;
	private bool inputAttack = false;
	Animator animator;
	Rigidbody2D rigidbody2D;
	Transform groundCheck;


	public float jumpRate = 0.25f;
	private float nextJumpTime = 0.0f;
	private roleState currentRoleState;

	private bool getAIButtonJump = false;
	private float getAIAxisHorizontal = 0f;
	private float thinkRate = 2f;
	private float nextThinkTime = 0f;
	private Vector2 seekPoint;

	// Use this for initialization
	void Start ()
	{
		groundCheck = transform.Find ("groundCheck");

		animator = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();

		thinkRate = thinkRate + Random.Range (-1f, 1f);
	}

	public void BalloonBroken ()
	{
		transform.Find ("BalloonTest").gameObject.active = false;
		transform.Find ("Parachute").gameObject.active = true;
	}

	void Update ()
	{
		if (transform.Find ("BalloonTest").gameObject.active == false) {
			return;
		}

		if (Time.time > nextThinkTime) {
			
			if (Vector2.Distance (transform.position, player.transform.position) < 7.0f) {
				
				if (transform.position.y >= player.transform.position.y) {
					//如果在主角上方 则进攻
					currentRoleState = roleState.RUNTOPLAYER;
					if (transform.position.y >= player.transform.position.y
					    && transform.position.x < player.transform.position.x) {
						getAIAxisHorizontal = 1;
					}
					if (transform.position.y >= player.transform.position.y
					    && transform.position.x > player.transform.position.x) {
						getAIAxisHorizontal = -1;
					}
				} else {
					if (transform.position.x < mainCamera.position.x) {
						getAIAxisHorizontal = 1;
					} else {
						getAIAxisHorizontal = -1;
					}
					currentRoleState = roleState.ESCAPE;
				}

			} else {
				currentRoleState = roleState.SEEK;
				seekPoint = new Vector2 (transform.position.x + Random.Range (-3f, 3f), transform.position.y + Random.Range (-3f, 3f));
				if (transform.position.x > seekPoint.x) {
					getAIAxisHorizontal = -1;
				} else {
					getAIAxisHorizontal = 1;
				}
			}
			nextThinkTime = Time.time + thinkRate;

		}

		switch (currentRoleState) {
		case roleState.RUNTOPLAYER:
			//玩家在范围内 击杀玩家
			//如果纵向比玩家低，距离太近的话 有可能会逃跑
			if (transform.position.y - player.transform.position.y < 1f) {
				getAIButtonJump = true;
			} else {
				getAIButtonJump = false;
			}


			break;
		case roleState.SEEK:
			//随机选择一个点 然后比对与这个点的距离
			if (transform.position.y < seekPoint.y) {
				getAIButtonJump = true;
			} else {
				getAIButtonJump = false;
			}
			break;
		case roleState.ESCAPE:
			//在主角下面 准备逃跑
			getAIButtonJump = true;
			/*if (transform.position.y < player.transform.position.y
				&& Mathf.Abs (transform.position.x - player.transform.position.x) < 5f) {
				//如果世界坐标在摄像机左面 则向右运动
				if (transform.position.x < mainCamera.position.x) {
					getAIAxisHorizontal = 1;
				} else {
					getAIAxisHorizontal = -1;
				}
			} 
			if (transform.position.y < player.transform.position.y
				&& Mathf.Abs (transform.position.x - player.transform.position.x) >= 5f) {
				if (transform.position.x - player.transform.position.x > 0) {
					getAIAxisHorizontal = -1;
				} else {
					getAIAxisHorizontal = 1;
				}
			}*/
			break;
		default:
			Debug.LogError ("motherfucker");
			break;
		}
		if (roleState.RUNTOPLAYER == currentRoleState) {
			//Debug.Log ("fuck");
		}

		animator.SetFloat ("Xspeed", Mathf.Abs (rigidbody2D.velocity.x));

		if (getAIAxisHorizontal != 0) {
			if (getAIAxisHorizontal < 0 && isFaceRight == true) {
				Flip ();
				isFaceRight = false;
			}
			if (getAIAxisHorizontal > 0 && isFaceRight != true) {
				Flip ();
				isFaceRight = true;
			}
			inputHorizontal = true;
			//ActionJump ();
		}

		if (getAIButtonJump) {
			ActionJump ();
		}

	}

	void StateRunToPlayer ()
	{
		
	}

	void StateSeek ()
	{
		
	}

	void ActionJump ()
	{
		
		if (Time.time > nextJumpTime) {
			animator.SetTrigger ("jump");
			inputJump = true;
			nextJumpTime = Time.time + jumpRate;
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{

		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		animator.SetBool ("grounded", grounded);

		//下落状态
		if (transform.Find ("Parachute").gameObject.active == true &&
		    transform.Find ("BalloonTest").gameObject.active == false) {
			if (grounded) {
				transform.Find ("Parachute").gameObject.active = false;
				return;
			}
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -1f);
			animator.SetBool ("landing", true);
			return;
		}
		//气球打气状态
		if (transform.Find ("Parachute").gameObject.active == false &&
		    transform.Find ("BalloonTest").gameObject.transform.localScale.x == 1 &&
		    transform.Find ("BalloonTest").gameObject.active == false) {
			transform.Find ("BalloonTest").gameObject.active = true;
			transform.Find ("BalloonTest").gameObject.transform.localScale = new Vector2 (0, 0);
			rigidbody2D.velocity = new Vector2 (0, 0);
			animator.SetBool ("landing", false);
			animator.SetBool ("casting", true);
			return;
		}
		if (transform.Find ("BalloonTest").gameObject.transform.localScale.x < 1 &&
		    transform.Find ("BalloonTest").gameObject.active == true) {
			//5秒打气
			transform.Find ("BalloonTest").gameObject.transform.localScale += new Vector3 (Time.deltaTime / 5, Time.deltaTime / 5, 0f);
			return;
		}
		//重置成正常正常状态
		if (transform.Find ("Parachute").gameObject.active == false &&
			transform.Find ("BalloonTest").gameObject.active == true &&
			transform.Find ("BalloonTest").gameObject.transform.localScale.x >= 1) {
			animator.SetBool ("casting", false);
		}

		if (inputHorizontal && grounded) {
			rigidbody2D.AddForce (new Vector2 (getAIAxisHorizontal * speed, 0));
			//Debug.Log (rigidbody2D.velocity.y);
			inputHorizontal = false;
		}
		if (inputHorizontal && inputJump) {
			rigidbody2D.AddForce (new Vector2 (getAIAxisHorizontal * speed, 0));
			//Debug.Log (rigidbody2D.velocity.y);
			inputHorizontal = false;
		}
		rigidbody2D.velocity = new Vector2 (Mathf.Clamp (rigidbody2D.velocity.x, -maxSpeed, maxSpeed), rigidbody2D.velocity.y);
		//Debug.Log (rigidbody2D.velocity.x);

		if (inputJump) {
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
			inputJump = false;
		}

		if (inputAttack) {
			rigidbody2D.velocity = new Vector2 (0, 0);
		}
		//print (grounded);
	}

	void Flip ()
	{
		transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
	}

	void OnTriggerEnter2D (Collider2D other)
	{

	}

	public void SetAIState (roleState sts, float t)
	{
		//aiState 			= sts;
		//aiActionTImeStart  	= Time.fixedTime;
		//aiActionTimeLength 	= t;
	}

	void seekPlayer ()
	{
		
	}
}
