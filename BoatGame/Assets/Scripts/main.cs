using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;


public class main : MonoBehaviour {

	public AudioSource correctsound;
	public AudioSource Incorrectsound;

	public GameObject GameOver;
	public GameOverScreen gameManager;

	public Image boostbar;	// boost bar image
	public float boost;		// variable to change boost
	public Text booster;

	public Transform player;	//player
	public Transform computer;	// computer1
	public Transform computer2; // computer2
	public Transform computer3; // computer3

	public Color cor;	// text colors for answer
	public Color inc;	// text colors for answer

	public Text Question;
	public Text Score;
	public Text distance;

	public Text Outcome;	
	public string Outcome1;

	public float speed = 0; // inital speed = 0
	public float oldspeed;

	public float num1;
	public float num2;

	public float number1;
	public float number2;

	public float userscore = 0;
	public Text playerspeed;
	public Text playerposition;

	public string inequality;
	public int inequalityval;

	public Text userscoreend;
	public Text userpositionend;
	public string positionend;
	public string finalposition;

	public double distancenum =1000; //start distance

	public double computerposition1 = 1000; // computer positions
	public double computerposition2 = 1000;
	public double computerposition3 = 1000;

	public int randomgen;


	public int c1;
	public int c2; 
	public int c3;
	public double constant =.1;

	public int a;
	public int b;
	public int c;

	public int speed1;
	public int speed11;
	public int speed22;
	public int speed33;

	public float PlayerTime;

	public float Player1FinalTime;
	public float Player2FinalTime;
	public float Player3FinalTime;
	public float userFinalTime;

	IEnumerator boostfunction ()
	{
		userscore = userscore + 100;
		speed = speed + 10;
		booster.text = "BOOSTING...";
		yield return new WaitForSeconds(3);
		speed = oldspeed;
		boost = 0f;
		boostbar.fillAmount = boost;
		booster.text = " ";
	}


	// analytics 
	public void correctAnalytics(int level){
		Analytics.CustomEvent("level"+level+": Correct");
	}
	public void incorrectAnalytics(int level){
		Analytics.CustomEvent("level"+level+": Incorrect");
	}
	public void firstplace(int level){
		Analytics.CustomEvent("placed first:"+level);
	}
	public void notfirstplace(int level){
		Analytics.CustomEvent("not placed first:"+level);
	}









	public float calc1(){
		return num1 = Random.Range (0,100);
	}

	public float calc2(){
		return num2 = Random.Range (0,100);
	}

	public float calc11(){
		return num1 = Random.Range (100,200);
	}

	public float calc22(){
		return num2 = Random.Range (100,200);
	}


	public void start(){
		Score.text = "score: " + userscore;
		distance.text = distancenum+"m";
	}
		

	public void moveplayers(){
		playerspeed.text = "Speed: " + speed;
		player.Translate (speed*Time.deltaTime,0, 0);
		computer.Translate (c1*Time.deltaTime,0, 0);
		computer2.Translate (c2*Time.deltaTime,0, 0);
		computer3.Translate (c3*Time.deltaTime,0, 0);
	}


	public void placing(){
		if ((Player1FinalTime > userFinalTime) || (Player2FinalTime > userFinalTime) || (Player3FinalTime> userFinalTime)) {positionend = "First";}
		if (((Player2FinalTime < userFinalTime) || (Player3FinalTime < userFinalTime)) && (Player1FinalTime> userFinalTime)|| ((Player1FinalTime < userFinalTime) || (Player3FinalTime < userFinalTime)) && (Player2FinalTime > userFinalTime)||((Player3FinalTime < userFinalTime) || (Player2FinalTime < userFinalTime)) && (Player1FinalTime > userFinalTime)){positionend = "Second";}
		if ((Player1FinalTime < userFinalTime) && ((Player2FinalTime > userFinalTime) || (Player3FinalTime > userFinalTime)) || (Player2FinalTime < userFinalTime) && ((Player1FinalTime > userFinalTime) || (Player3FinalTime > userFinalTime)) || (Player3FinalTime < userFinalTime) && ((Player2FinalTime > userFinalTime) || (Player1FinalTime > userFinalTime))){positionend = "Third";}
		if ((Player1FinalTime < userFinalTime) && (Player2FinalTime < userFinalTime) && (Player3FinalTime < userFinalTime)) {positionend = "Last";}
	}

}
