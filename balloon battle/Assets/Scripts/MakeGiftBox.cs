using UnityEngine;
using System.Collections;

public class MakeGiftBox : MonoBehaviour {
	//被吃了之后10秒开始生成新的一个
	public int liftTime = 10;
	public GameObject giftBox;

	private float lifeTimeStamp = 0f;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

//		Time.time;
		if(Time.time > lifeTimeStamp + liftTime){
			Instantiate (giftBox,new Vector2(Random.Range(-8,8),4),Quaternion.identity);
			lifeTimeStamp = Time.time;
		}
	}
}
