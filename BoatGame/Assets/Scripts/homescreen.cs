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
		//Button btn = reset.GetComponent<Button> ();
		//btn.onClick.AddListener (resetgame);
		//btn.onClick.AddListener (printscore);
		printscore ();
	}
	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";
	public static string descriptionParam;
	private string appStoreLink = "http://www.YOUROWNAPPLINK.com";


	public void ShareToTW()
	{

		string nameParameter = "Hey my High score is: "+highScore+"!. Lets try to see you beat it";

		Application.OpenURL(TWITTER_ADDRESS +
			"?text=" + WWW.EscapeURL(nameParameter + "\n" + descriptionParam + "\n" + "Get the Game:\n" + appStoreLink));
	}


	void printscore(){
		sumscore = PlayerPrefs.GetFloat ("level1score") + PlayerPrefs.GetFloat ("level2score") + PlayerPrefs.GetFloat ("level3score")+ PlayerPrefs.GetFloat ("level4score")+ PlayerPrefs.GetFloat ("level5score")+ PlayerPrefs.GetFloat ("level6score");	
		float highScore = sumscore;
		hiscore.text = "High Score: "+ highScore;
	}

	/*
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
	*/


	// Update is called once per frame
	void Update () {
		printscore ();
	}
}
