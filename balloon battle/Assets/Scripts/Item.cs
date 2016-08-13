using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	public Image image;
	private string itemName = "";

	// Use this for initialization
	void Start ()
	{
		if (itemName.Length < 1) {
			image.sprite = null;
			image.color = new Color (image.color.r, image.color.g, image.color.b, 0);
		}

		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1") && itemName.Length > 0) {
			//Invoke ("Item_" + itemName, 0);
			StartCoroutine ("Item_" + itemName);//协同程序

			itemName = "";
			image.sprite = null;
			image.color = new Color (image.color.r, image.color.g, image.color.b, 0);
		}
	}

	void showItemUI (string itemName)
	{
		image.sprite = Resources.Load ("Sprites/item_" + itemName, typeof(Sprite)) as Sprite;
		image.color = new Color (image.color.r, image.color.g, image.color.b, 255);
	}
	 

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.name == "GiftBox(Clone)") {
			itemName = getRandomItemName ();
			showItemUI (itemName);
		}
	}

	string getRandomItemName ()
	{
		string[] itemNameArray = new string[]{ "Clock" };
		return itemNameArray [Random.Range (0, itemNameArray.Length)];
	}
	//检测使用物品按钮，如果按下之后 检测现在所拥有的item是啥 然后switch调用每一个物品是方法 然后摧毁物品

	/*******************以下为一个物品一个方法*******************/
	IEnumerator Item_Clock ()
	{
		Time.timeScale = 1.5f;
		yield return new WaitForSeconds(1f);
		Time.timeScale = 1.0f;
	}

}
