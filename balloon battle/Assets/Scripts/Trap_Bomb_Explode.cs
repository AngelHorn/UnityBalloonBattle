using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Trap_Bomb_Explode : MonoBehaviour {
	private float bornTime;
	public int duration = 1;

	// Use this for initialization
	void Start () {
		bornTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - bornTime > duration){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			SceneManager.LoadScene ("S4");
		}
	}
}
