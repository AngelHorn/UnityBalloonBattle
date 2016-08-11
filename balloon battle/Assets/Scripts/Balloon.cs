using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * 如果一个气球碰到了player层或者是enemy层的任何内容的时候就要爆炸
		 * 
		 * 
		 * 
		 * 
		 */
	}
	void OnCollisionExit2D(Collision2D other){
		string myTagName = gameObject.transform.parent.tag;
		string otherTagName = other.gameObject.tag;
		if(myTagName == "Player" && otherTagName == "Enemy"){
			Application.LoadLevel ("Scenes/S2");
		}
		if(myTagName == "Enemy" && otherTagName == "Player"){
			Destroy (gameObject.transform.parent.gameObject);
		}
		if(myTagName == "Player" && otherTagName == "Player"){
			Application.LoadLevel ("Scenes/S2");
		}
	}
	void OnTriggerStay2D(Collider2D other){
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
