using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour
{
	public AudioClip BoomSE;
	AudioSource audioSource;


	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		 * 如果一个气球碰到了player层或者是enemy层的任何内容的时候就要爆炸
		 * 
		 * 
		 * 
		 * 
		 */
	}

	void OnCollisionExit2D (Collision2D other)
	{
		string myTagName = gameObject.transform.parent.tag;
		string otherTagName = other.gameObject.tag;
		//敌人打主角
		if (myTagName == "Player" && otherTagName == "Enemy") {
			if(other.gameObject.transform.Find ("BalloonTest").gameObject.GetComponent<Renderer> ().enabled == false ||
				other.gameObject.transform.Find ("BalloonTest").gameObject.transform.localScale.x < 1){
				return;
			}
			Application.LoadLevel ("Scenes/S2");
		}
		//主角打敌人
		if (myTagName == "Enemy" && otherTagName == "Player") {
			//禁用气球  启用降落伞  
			audioSource.clip = BoomSE;
			audioSource.Play ();

			gameObject.transform.parent.gameObject.GetComponent<EnemyAI> ().BalloonBroken ();
//			Destroy (gameObject.transform.parent.gameObject);
		}

		if (myTagName == "Player" && otherTagName == "Player") {
			Application.LoadLevel ("Scenes/S2");
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
//		string myTagName = gameObject.transform.parent.tag;
//		string otherTagName = other.gameObject.tag;
//		if(myTagName == "Player" && otherTagName == "Enemy"){
//			Application.LoadLevel ("Scenes/S2");
//		}
//		if(myTagName == "Enemy" && otherTagName == "Player"){
//			Destroy (gameObject.transform.parent.gameObject);
//		}
//		if(myTagName == "Player" && otherTagName == "Player"){
//			Application.LoadLevel ("Scenes/S2");
//		}
	}
}
