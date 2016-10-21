using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Trap_Bomb : MonoBehaviour {
	public Sprite counter_3;
	public Sprite counter_2;
	public Sprite counter_1;
	public GameObject explode;
	private float timer = 0f;
	private bool isCounting = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isCounting) {
			CountingStart ();
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			timer = Time.time;
			isCounting = true;
		}
	}

	void CountingStart(){
		if(Time.time - timer >= 3){
			Boom ();
			isCounting = false;
		} else if (Time.time - timer >= 2) {
			transform.FindChild ("Counter").GetComponent<SpriteRenderer> ().sprite = counter_1;
		} else if (Time.time - timer >= 1) {
			transform.FindChild ("Counter").GetComponent<SpriteRenderer> ().sprite = counter_2;
		} else if (Time.time - timer >= 0) {
			transform.FindChild ("Counter").GetComponent<SpriteRenderer> ().sprite = counter_3;
		}
	}

	void Boom(){
		GameObject bulletPrefab = Instantiate (explode, transform.position, explode.transform.rotation) as GameObject;
		Destroy (gameObject);
	}
}
