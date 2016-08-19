using UnityEngine;
using System.Collections;

public class CameraCommon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
//			Debug.Log ("OnTriggerEnter2D");

			Destroy (other.gameObject);
		}
	}
}
