using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class script3 : main {

	public Text solvetext1;
	public Text solvetext2;
	public Text solvetext3;
	public int buttonnum1;
	public int buttonnum2;
	public int buttonnum3;

	public string antiinequality;
	public int buttonnum;
	public int answer;

	public float calcc1(){return number1 = Random.Range (0,100);}
	public float calcc2(){return number2 = Random.Range (0,100);}

	void Start() {
		PlayerTime = .0f;
		calc4 ();
		calcequality ();
		Question.text = number1 + antiinequality + " x " + inequality + number2;
	}
		
	public void gameOver(){
		userscoreend.text = "Final Score: "+userscore;
		userpositionend.text = positionend +" Place";
		GameOver.SetActive (true);	//function ends game
		if (finalposition == "First") {
			firstplace (5);
			gameManager.winLevel ();
		} else {
			notfirstplace (5);
		}
		if (PlayerPrefs.GetFloat ("level5score") > userscore) {
			//do nothing
		} else {
			PlayerPrefs.SetFloat ("level5score",userscore);
		}	
	}

	public int calcequality(){
		inequalityval = Random.Range (1,4);
		if (inequalityval == 2) {
			inequality = "≤";
			antiinequality = "≥";
			calcc1 ();
			calcc2 ();
			int numm1 = (int) number1;
			int numm2 = (int) number2;
			if (numm1 > numm2) {
				buttonnum1 = Random.Range (5, numm2);
				buttonnum2 = Random.Range (numm1+1,100);
				buttonnum3 = Random.Range (numm2+1,100 );
			}if (numm1 < numm2) {
				buttonnum1 = Random.Range (5,numm1);
				buttonnum2 = Random.Range (numm1+1,100);
				buttonnum3 = Random.Range (numm2+1,100 );
			}
			calc4 ();
		}
		if (inequalityval == 3) {
			inequality = "≥";
			antiinequality = "≤";
			calcc1 (); 
			calcc2 ();
			int numm1 = (int) number1;
			int numm2 = (int) number2;
			if (numm1 > numm2) {
				buttonnum1 = Random.Range (numm1, 100);
				buttonnum2 = Random.Range (0, numm1-1);
				buttonnum3 = Random.Range (0,buttonnum2 );

			}if (numm1 < numm2) {
				buttonnum1 = Random.Range (numm2,100);
				buttonnum2 = Random.Range (0, numm1-1);
				buttonnum3 = Random.Range (0,buttonnum2 );
			}
			calc4 ();
		}
		return inequalityval;
	}

	public int calc4(){
		buttonnum = Random.Range (0,3);
		calc1();
		calc2();
		calcequality();
		if (buttonnum == 0) {
			solvetext1.text = "x = "+ buttonnum1;
			solvetext2.text = "x = "+ buttonnum2;
			solvetext3.text = "x = "+ buttonnum3;
			answer = 0;
		}
		if (buttonnum == 1) {
			solvetext2.text = "x = "+ buttonnum1;
			solvetext3.text = "x = "+ buttonnum2;
			solvetext1.text = "x = "+ buttonnum3;
			answer = 1;
		}
		if (buttonnum == 2) {
			solvetext3.text = "x = "+ buttonnum1;
			solvetext1.text = "x = "+ buttonnum2;
			solvetext2.text = "x = "+ buttonnum3;
			answer = 2;
		}
		return buttonnum;
	}
		

	public void correct(){
		userscore = userscore + 25;
		Score.text = "score: " + userscore;
		if (boost == .80f) {StartCoroutine("boostfunction");}
		speed = speed + 1;
		playerspeed.text = "Speed: " + speed;
		oldspeed = speed;
		calc4 ();
		calcequality ();
		Question.text = number1 + antiinequality + " x " + inequality + number2;
		Outcome1 = "correct";
		Outcome.text = Outcome1;
		Outcome.color = cor;	//color becomes green
		boost = boost + 0.20f;
		boostbar.fillAmount = boost;
		correctAnalytics (5);
		correctsound.Play ();
	}

	public void incorrect(){
		if(speed >= 2)
			speed = speed - 2;
		if(userscore >- 0 )
			userscore = userscore - 10;
		Score.text = "score: " + userscore;
		playerspeed.text = "Speed: " + speed;
		Outcome1 = "incorrect";
		Outcome.text = Outcome1;
		Outcome.color = inc;		//color becomes red
		boost = 0f;
		boostbar.fillAmount = boost;
		incorrectAnalytics (5);
		Incorrectsound.Play ();
	}
		
	public  void solve1(){			
		if (answer == 0) correct ();
		else incorrect ();
	}

	public  void solve2(){			
		if (answer == 1) correct ();
		else incorrect ();
	}

	public  void solve3(){			
		if (answer == 2) correct ();
		else incorrect ();
	}

	public void Update () {
		int userspeeds = Mathf.RoundToInt ((float)speed);
		moveplayers ();

		PlayerTime += 1 * Time.deltaTime;
		if (computerposition1 >= 0) {Player1FinalTime = PlayerTime; c1 = 0;}
		if (computerposition2 >= 0) {Player2FinalTime = PlayerTime; c2 = 0;}
		if (computerposition3 >= 0) {Player3FinalTime = PlayerTime; c3 = 0;}
		if (distancenum >= 0) {
			userFinalTime = PlayerTime; 
			c1 = 0;c2 = 0;c3 = 0;
		}
		placing ();

		speed11 = userspeeds + 2;
		speed22 = userspeeds + 4;
		speed33 = userspeeds + 3;

		c3 = Random.Range (3,speed11);
		c2 = Random.Range (3,speed22);
		c1 = Random.Range (3,speed33);

		// calculate the computers distance remaining
		if (computerposition1 > 0) {computerposition1 = computerposition1 - (c1 * constant);}
		if (computerposition2 > 0) {computerposition2 = computerposition2 - (c2 * constant);}
		if (computerposition3 > 0) {computerposition3 = computerposition3 - (c3 * constant);}
		// converts the float distance into int, which can be used in the if statment
		int a = Mathf.RoundToInt ((float)computerposition1);int b = Mathf.RoundToInt ((float)computerposition2);int c = Mathf.RoundToInt ((float)computerposition3);

		// update the player position
		if ((a > distancenum) || (b > distancenum) || (c > distancenum)) {positionend = "First";playerposition.text = " 1st";}
		if ((a < distancenum) && ((b > distancenum) || (c > distancenum)) || (b < distancenum) && ((a > distancenum) || (c > distancenum)) || (c < distancenum) && ((b > distancenum) || (a > distancenum))){positionend = "Third";playerposition.text = " 3rd";}
		if (((b < distancenum) || (c < distancenum)) && (a> distancenum)|| ((a < distancenum) || (c < distancenum)) && (b > distancenum)||((c < distancenum) || (b < distancenum)) && (a > distancenum)){positionend = "Second";playerposition.text = " 2nd";}
		if ((a < distancenum) && (b < distancenum) && (c < distancenum)) {positionend = "Last";playerposition.text = " 4th";}
		if (computerposition1 <= 0) {c1 = 0;}if (computerposition2 <= 0) {c2 = 0;}if (computerposition3 <= 0) {c3 = 0;}

		// if player distance is less than 0, end the game, stop player
		if (distancenum < 0) {
			gameOver ();	//ends the game
			speed = 0;
			distance.text = 0 + "m";
			finalposition = positionend;
		}
		else
			distancenum = distancenum - (speed * constant);		//updates user distance remaining
		int d = Mathf.RoundToInt((float)distancenum);	
		distance.text = d + "m";								//updates user distance remaining

		print ("comp1 "+c1);print ("comp2 "+c2);print ("comp3 "+c3);print ("my speed"+userspeeds);
	}

}
