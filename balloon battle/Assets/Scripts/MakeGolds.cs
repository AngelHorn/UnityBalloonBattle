using UnityEngine;
using System.Collections;

public class MakeGolds : MonoBehaviour
{

	public GameObject goldPrefab;
	private int goldNum = 50;

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < goldNum; i++) {
			float position_X = i;
			float position_Y = Random.Range (-2, 2);
			initGoldList (position_X,position_Y);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}


	void initGoldList (float position_X,float position_Y)
	{
		Instantiate (goldPrefab, new Vector3 (position_X, position_Y, 0), Quaternion.identity);
	}
}
