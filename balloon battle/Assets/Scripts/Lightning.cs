using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector2 speedVector = new Vector2 (Random.Range (1f, 5f), Random.Range (1f, 5f));
//		Vector2 speedVector = new Vector2 (10, 5);

		GetComponent<Rigidbody2D> ().velocity = speedVector;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (GetComponent<Rigidbody2D> ().velocity);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel ("Scenes/S2");
		}
	}
}
