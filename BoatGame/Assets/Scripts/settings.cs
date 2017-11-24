using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour {


	public Button reset;

	void Start () {
		Button btn = reset.GetComponent<Button> ();
		btn.onClick.AddListener (resetgame);	
	}
	
	void resetgame(){
		PlayerPrefs.SetInt("levelReached",1);
		Debug.Log ("game is reset");
		PlayerPrefs.SetFloat ("level1score",0);
		PlayerPrefs.SetFloat ("level2score",0);
		PlayerPrefs.SetFloat ("level3score",0);
		PlayerPrefs.SetFloat ("level4score",0);
		PlayerPrefs.SetFloat ("level5score",0);
		PlayerPrefs.SetFloat ("level6score",0);

	}


}

