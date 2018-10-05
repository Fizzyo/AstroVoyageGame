using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inventoryScore : MonoBehaviour {

	private int score;
	// Use this for initialization
	void Start () 
    {
		score = PlayerPrefs.GetInt ("highscore", 0);
		TextMeshProUGUI obj = gameObject.GetComponent<TextMeshProUGUI>();
		obj.SetText (score.ToString ());
	}
	
	//// Update is called once per frame
	//void Update () {
	//}
}
