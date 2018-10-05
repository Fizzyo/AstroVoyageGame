using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class inventoryShipUnlock : MonoBehaviour {
	public static selectedShip chosenShip = selectedShip.orangeBall;
	public selectedShip thisShip;
	public int scoreCost = 0;
	// Use this for initialization

	void Start () {
		Button bttn = gameObject.GetComponent<Button> ();
		int score = PlayerPrefs.GetInt ("highscore", 0);
		if (score < scoreCost) {
			bttn.interactable = false;
		} else {
			bttn.interactable = true;
		}
		bttn.onClick.AddListener (changeChoice);
			
	}
	void changeChoice(){
		string str;
		chosenShip = thisShip;
		str = chosenShip.ToString();
		PlayerPrefs.SetString ("ship", str);
	}
	// Update is called once per frame
	void Update () {
		
	}


}
public enum selectedShip{
	orangeBall,
	greyShip,
	yellowShip,
	llama
}