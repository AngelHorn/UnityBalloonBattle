using UnityEngine;
using System.Collections;

public class Sea : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel ("Scenes/S2");
		}
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Item"){
			Destroy (other.gameObject);
		}
	}
}
