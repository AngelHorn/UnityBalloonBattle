﻿using UnityEngine;
using System.Collections;

public class Parachute : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionExit2D (Collision2D other)
	{
		string myTagName = gameObject.transform.parent.tag;
		string otherTagName = other.gameObject.tag;
		if (myTagName == "Player" && otherTagName == "Enemy") {
			Application.LoadLevel ("Scenes/S2");
		}
		if (myTagName == "Enemy" && otherTagName == "Player") {
			Destroy (gameObject.transform.parent.gameObject);
		}
		if (myTagName == "Player" && otherTagName == "Player") {
			Application.LoadLevel ("Scenes/S2");
		}
	}
}
