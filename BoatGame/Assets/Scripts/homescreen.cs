using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class homescreen : MonoBehaviour {


	//public Button reset;
	public Text hiscore;
	public float sumscore;
	public float highScore;

	void Start(){

	//when the app is opened for the first time set default to easy mode.
		if(	(PlayerPrefs.GetInt("numhigh") == 0) || (PlayerPrefs.GetInt("numhigh2") == 0) ||  (PlayerPrefs.GetInt("numlow2") == 0)	)
		{
			PlayerPrefs.SetInt("numlow",0);PlayerPrefs.SetInt("numhigh",25);PlayerPrefs.SetInt("numlow2",25);PlayerPrefs.SetInt("numhigh2",50);PlayerPrefs.SetString("display","Game is set to easy");PlayerPrefs.SetString("sociallevel","easy");
			PlayerPrefs.SetInt("easyspeed1",2);PlayerPrefs.SetInt("easyspeed1",4);PlayerPrefs.SetInt("easyspeed1",3);
			PlayerPrefs.SetInt("easyspeed1",9);PlayerPrefs.SetInt("easyspeed2",12);PlayerPrefs.SetInt("easyspeed3",8);PlayerPrefs.SetInt ("easyspeed01", 5);//easy 1,3,5
			PlayerPrefs.SetInt("easyspeed11",15);PlayerPrefs.SetInt("easyspeed22",13);PlayerPrefs.SetInt("easyspeed33",16);PlayerPrefs.SetInt ("easyspeed011", 5);//easy 2,4,6
			PlayerPrefs.SetInt("boost_score",100);PlayerPrefs.SetInt("bonus_score",300);
		
		}
		printscore ();
	}


	//post score to twitter stuff
	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";
	public static string descriptionParam;
	private string appStoreLink = "http://www.YOUROWNAPPLINK.com";


	public void ShareToTW()
	{

		string nameParameter = "Hey, I just played Boat Racer!!!! My High score is: "+sumscore+"! I played this game on "+PlayerPrefs.GetString("sociallevel")+" difficulty. I bet you can't beat me score!";

		Application.OpenURL(TWITTER_ADDRESS +
			"?text=" + WWW.EscapeURL(nameParameter + "\n" + descriptionParam + "\n" + "Get the Game:\n" + appStoreLink));
	}


	void printscore(){
		sumscore = PlayerPrefs.GetFloat ("level1score") + PlayerPrefs.GetFloat ("level2score") + PlayerPrefs.GetFloat ("level3score")+ PlayerPrefs.GetFloat ("level4score")+ PlayerPrefs.GetFloat ("level5score")+ PlayerPrefs.GetFloat ("level6score");	
		float highScore = sumscore;
		hiscore.text = "High Score: "+ highScore;
	}
		

	// Update is called once per frame
	void Update () {
		printscore ();
	}
}
