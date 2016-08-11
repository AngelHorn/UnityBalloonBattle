using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float speed = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed*Time.deltaTime,transform.position.y,0);
	}
}
