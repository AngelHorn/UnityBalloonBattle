using UnityEngine;
using System.Collections;

public class Trap_Cannon_Laser : MonoBehaviour {
	public GameObject Laser;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Shoot",0,2);
		InvokeRepeating ("CancelShoot",1,2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot(){
		GameObject bulletPrefab = Instantiate (Laser, transform.position, Laser.transform.rotation) as GameObject;
		bulletPrefab.transform.SetParent (transform);

	}

	void CancelShoot(){
		for(int i=0;i<transform.childCount;i++){
			Destroy (transform.GetChild(i).gameObject);
		}

	}
}
