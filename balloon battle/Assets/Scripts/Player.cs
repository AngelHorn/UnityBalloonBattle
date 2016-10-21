using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	public float jumpForce;
	public float speed;
	public AudioClip jumpSE;
	public AudioClip readyToShot;
	public Canvas canvas;

	private float maxSpeed = 15f;

	private bool grounded = true;
	private bool isFaceRight = true;
	private bool inputHorizontal = false;
	private bool inputJump = false;
	private bool inputAttack = false;
	Animator animator;
	Rigidbody2D rigidbody2D;
	Transform groundCheck;
	AudioSource audioSource;

	public float jumpRate = 0.25f;
	private float nextJumpTime = 0.0f;

	// Use this for initialization
	void Start ()
	{
		groundCheck = transform.Find ("groundCheck");

		animator = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		animator.SetFloat ("Xspeed", Mathf.Abs (rigidbody2D.velocity.x));


		if (Input.GetAxis ("Horizontal") != 0) {
			if (Input.GetAxis ("Horizontal") < 0 && isFaceRight == true) {
				Flip ();
				isFaceRight = false;
			}
			if (Input.GetAxis ("Horizontal") > 0 && isFaceRight != true) {
				Flip ();
				isFaceRight = true;
			}
			inputHorizontal = true;
		}
			
		if (Input.GetButton ("Jump") && Time.time > nextJumpTime) {
			animator.SetTrigger ("jump");
			audioSource.clip = jumpSE;
			audioSource.Play ();
			inputJump = true;
			nextJumpTime = Time.time + jumpRate;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		/*
			在气球大战中，不是直接控制力的大小，而是直接控制速度。速度和车的档位类似。一共分5档。比如12345。加速间隔为0.2秒。
			假如按住一个按键1秒。那么player将会达到最大速度5。反向按1秒就会把速度变成0.
		*/
		if (inputHorizontal && grounded) {
			rigidbody2D.AddForce (new Vector2(Input.GetAxis ("Horizontal") * speed,0));
			//Debug.Log (rigidbody2D.velocity.y);
			inputHorizontal = false;
		}
		if(inputHorizontal && inputJump){
			rigidbody2D.AddForce (new Vector2(Input.GetAxis ("Horizontal") * speed,0));
			//Debug.Log (rigidbody2D.velocity.y);
			inputHorizontal = false;
		}
		rigidbody2D.velocity = new Vector2 (Mathf.Clamp(rigidbody2D.velocity.x,-maxSpeed,maxSpeed), rigidbody2D.velocity.y);
		//Debug.Log (rigidbody2D.velocity.x);

		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		animator.SetBool ("grounded", grounded);

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
		if (other.name != "gold(Clone)") {
			return;
		}
		goldScoreAdd ();
	}

	void goldScoreAdd(){
		Text numText = canvas.transform.Find("num").GetComponent<Text> ();
		numText.text = (int.Parse (numText.text) + 1).ToString ();
		//num.text = (int.Parse (num.text) + 1).ToString ();
		//Debug.Log (int.Parse (num.text) + 1);
	}


}
