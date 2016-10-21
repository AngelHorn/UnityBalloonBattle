using UnityEngine;
using System.Collections;

public class CameraS4 : MonoBehaviour {

	public Transform player;
	int XRange = 5;
	int YRange = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*
		 *画一个小方块  如果人在小方块里面 那就慢动
		 *如果人贴在了小方块上面，那么人的XY移动和摄像机的XY移动就一样了。
		 */



		float difX = player.position.x - transform.position.x;
		float difY = player.position.y - transform.position.y;

		if (difX > XRange) {
			transform.position = new Vector3 ((transform.position.x + difX - XRange), transform.position.y, transform.position.z);
		} else if (difX < -XRange) {
			transform.position = new Vector3 ((transform.position.x + difX + XRange), transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (Mathf.SmoothStep (transform.position.x,player.position.x,0.1f), transform.position.y, transform.position.z);
		}


		if (difY > YRange) {
			transform.position = new Vector3 (transform.position.x, (transform.position.y + difY - YRange), transform.position.z);
		} else if (difY < -YRange) {
			transform.position = new Vector3 (transform.position.x, (transform.position.y + difY + YRange), transform.position.z);
		} else {
			transform.position = new Vector3 (transform.position.x, Mathf.SmoothStep (transform.position.y,player.position.y,0.1f),transform.position.z);
		}



	}
}
