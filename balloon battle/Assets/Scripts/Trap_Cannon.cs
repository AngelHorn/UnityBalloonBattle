using UnityEngine;
using System.Collections;

public class Trap_Cannon : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Shoot",0,2);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Shoot(){
		GameObject bulletPrefab = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;

		bulletPrefab.GetComponent<Rigidbody2D>().velocity = RotationMatrix(new Vector2(1,1),Random.Range(-90,90));

	}

	Vector2 RotationMatrix(Vector2 v,float angle){
		var x = v.x;
		var y = v.y;
		var sin = Mathf.Sin (Mathf.PI*angle/180);
		var cos = Mathf.Cos (Mathf.PI*angle/180);
		var newX = x * cos + y * sin;
		var newY = x * -sin + y * cos;
		return new Vector2((float) newX,(float) newY);
	}

}
