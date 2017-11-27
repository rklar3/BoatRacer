using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficulty : MonoBehaviour {



	public GameObject easybutton;	//easy
	public GameObject mediumbutton;	//medium
	public GameObject hardbutton;	//hard
	public Button reset;
	public Text display;

	void Start () {
		Button btn = reset.GetComponent<Button> ();
		btn.onClick.AddListener (resetgame);

		display.text = PlayerPrefs.GetString ("display");

	}

	public void easybuttonclick(){
		PlayerPrefs.SetInt("numlow",0);
		PlayerPrefs.SetInt("numhigh",25);

		PlayerPrefs.SetInt("numlow2",25);
		PlayerPrefs.SetInt("numhigh2",50);


		PlayerPrefs.SetInt("score_correct",25);
		PlayerPrefs.SetInt("score_incorrect",5);
		PlayerPrefs.SetInt("boost_score",100);
		PlayerPrefs.SetInt("bonus_score",300);


		PlayerPrefs.SetString("display","Game is set to easy");
		display.text = ""+PlayerPrefs.GetString ("display");
		PlayerPrefs.SetString("sociallevel","easy");

		//easy 1,3,5
		PlayerPrefs.SetInt("easyspeed1",9);PlayerPrefs.SetInt("easyspeed2",12);PlayerPrefs.SetInt("easyspeed3",8);
		PlayerPrefs.SetInt ("easyspeed01", 5);

		//easy 2,4,6
		PlayerPrefs.SetInt("easyspeed11",15);PlayerPrefs.SetInt("easyspeed22",13);PlayerPrefs.SetInt("easyspeed33",16);
		PlayerPrefs.SetInt ("easyspeed011", 5);

		resetgame ();

	}

	public void mediumbuttonclick(){
		PlayerPrefs.SetInt("numlow", 0);
		PlayerPrefs.SetInt("numhigh",100);

		PlayerPrefs.SetInt("numlow2",100);
		PlayerPrefs.SetInt("numhigh2",200);

		PlayerPrefs.SetInt("score_correct",50);
		PlayerPrefs.SetInt("score_incorrect",15);
		PlayerPrefs.SetInt("boost_score",200);
		PlayerPrefs.SetInt("bonus_score",1200);

	
		PlayerPrefs.SetString("display","Game is set to medium");
		display.text = ""+PlayerPrefs.GetString ("display");
		PlayerPrefs.SetString("sociallevel","medium");

		//medium 1,3,5
		PlayerPrefs.SetInt("easyspeed1",14);PlayerPrefs.SetInt("easyspeed2",15);PlayerPrefs.SetInt("easyspeed3",16);
		PlayerPrefs.SetInt ("easyspeed01", 9);

		//medium 2,4,6
		PlayerPrefs.SetInt("easyspeed11",15);PlayerPrefs.SetInt("easyspeed22",12);PlayerPrefs.SetInt("easyspeed33",13);
		PlayerPrefs.SetInt ("easyspeed011", 8);

		resetgame ();
	}

	public void hardbuttonclick(){
		PlayerPrefs.SetInt("numlow",300);
		PlayerPrefs.SetInt("numhigh",500);

		PlayerPrefs.SetInt("numlow2",300);
		PlayerPrefs.SetInt("numhigh2",500);

		PlayerPrefs.SetInt("score_correct",100);
		PlayerPrefs.SetInt("score_incorrect",25);
		PlayerPrefs.SetInt("boost_score",300);
		PlayerPrefs.SetInt("bonus_score",2000);


		PlayerPrefs.SetString("display","Game is set to hard");
		display.text = ""+PlayerPrefs.GetString ("display");
		PlayerPrefs.SetString("sociallevel","Hard");

		//hard 1,3,5
		PlayerPrefs.SetInt("easyspeed1",16);PlayerPrefs.SetInt("easyspeed2",17);PlayerPrefs.SetInt("easyspeed3",18);
		PlayerPrefs.SetInt ("easyspeed01", 8);

		//hard 2,4,6
		PlayerPrefs.SetInt("easyspeed11",14);PlayerPrefs.SetInt("easyspeed22",15);PlayerPrefs.SetInt("easyspeed33",13);
		PlayerPrefs.SetInt ("easyspeed011", 9);

		resetgame ();

	}


	public void resetgame(){
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
