using UnityEngine;
using System.Collections;

public class Trigger_Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player" && other.relativeVelocity.magnitude > 10){
			Destroy (gameObject);
			GetComponent<SpriteRenderer> ();
		}
	}
}
