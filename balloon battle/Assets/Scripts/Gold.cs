using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{

	public GameObject num;

	// Use this for initialization
	void Start ()
	{
		
	}


	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name != "player") {
			return;
		}
		Destroy (gameObject);
	}

}
