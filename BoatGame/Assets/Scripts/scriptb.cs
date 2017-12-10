using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class scriptb : main {



	private void Start() {
		askquestion ();
		PlayerTime = .0f;

	}
		
	public void gameOver(){

		userscoreend.text = "Final Score: " + PlayerPrefs.GetFloat ("level2score");
		userpositionend.text = positionend +" Place";
		GameOver.SetActive (true);	//function ends game
		if (finalposition == "First") {
			firstplace (2);
			gameManager.winLevel ();
		} else {
			notfirstplace (2);
		}
		if (PlayerPrefs.GetFloat ("level2score") > userscore) {
			//do nothing
		} else {
			PlayerPrefs.SetFloat ("level2score",userscore+PlayerPrefs.GetInt("bonus_score"));
		}

	}


	int equalsineq =0;

	private int calcequality()
	{
		calc11 ();		// first random number
		calc22 ();		// second random number
		inequalityval = Random.Range (0,3);
		if (inequalityval == 0)
			inequality = " > ";
		if (inequalityval == 1)
			inequality = " < ";
		if (inequalityval == 2) {
			inequality = " = ";
			equalsineq = Random.Range (0,2);
			//print (equalsineq);
			if (equalsineq == 1) {
				num2 = num1;
			}
		}
		return inequalityval;
	}


	private void askquestion(){
		calcequality ();	
		Question.text = num1 + inequality + num2 ;
	}


	void correct(){
		userscore = userscore + PlayerPrefs.GetInt("score_correct");
		Score.text = "score: " + userscore;
		oldspeed = speed;
		if (boost == .80f) {StartCoroutine("boostfunction");}
		speed = speed + 1;
		playerspeed.text = "Speed: " + speed;
		Outcome1 = "correct";
		Outcome.text = Outcome1;
		Outcome.color = cor;	//color becomes green
		boost = boost + 0.20f;
		boostbar.fillAmount = boost;
		askquestion ();
		correctAnalytics (2);
		correctsound.Play ();

	}

	public void incorrect(){
		if(speed >= 2)
			speed = speed - 2;
		if(userscore >= 0 )
			userscore = userscore - PlayerPrefs.GetInt("score_incorrect");
		Score.text = "score: " + userscore;
		playerspeed.text = "Speed: " + speed;
		Outcome1 = "incorrect";
		Outcome.text = Outcome1;
		Outcome.color = inc;		//color becomes red
		boost = 0f;
		boostbar.fillAmount = boost;
		incorrectAnalytics (2);
		Incorrectsound.Play ();
	}

	// when user clicks true button
	public void True(){
		switch (inequalityval) {
		case 0:
			if (num1 > num2) {
				correct ();
			} else {
				incorrect ();
			}
			break;
		case 1:
			if (num1 < num2) {
				correct ();
			} else {
				incorrect ();
			}
			break;
		case 2:
			if (num1 == num2) {
				correct ();
			} else {
				incorrect ();
			}
			break;
		}
	}

	// when user clicks false button
	public void False(){			
		switch (inequalityval) {
		case 0:
			if (num1 <= num2) {
				correct ();
			} else {
				incorrect ();
			}
			break;
		case 1:
			if (num1 >= num2) {
				correct ();
			} else {
				incorrect ();
			}
			break;
		case 2:
			if (num1 != num2) {
				correct ();
			} else {
				incorrect ();
			}
			break;
		}
	}
		
	public void Update () {
		moveplayers ();

		PlayerTime += 1 * Time.deltaTime;
		if (computerposition1 >= 0) {Player1FinalTime = PlayerTime; c1 = 0;}
		if (computerposition2 >= 0) {Player2FinalTime = PlayerTime; c2 = 0;}
		if (computerposition3 >= 0) {Player3FinalTime = PlayerTime; c3 = 0;}
		if (distancenum >= 0) {
			userFinalTime = PlayerTime; 
			c1 = 0;c2 = 0;c3 = 0;
		}
		if ((Player1FinalTime > userFinalTime) || (Player2FinalTime > userFinalTime) || (Player3FinalTime> userFinalTime)) {positionend = "First";}
		if (((Player2FinalTime < userFinalTime) || (Player3FinalTime < userFinalTime)) && (Player1FinalTime> userFinalTime)|| ((Player1FinalTime < userFinalTime) || (Player3FinalTime < userFinalTime)) && (Player2FinalTime > userFinalTime)||((Player3FinalTime < userFinalTime) || (Player2FinalTime < userFinalTime)) && (Player1FinalTime > userFinalTime)){positionend = "Third";}
		if ((Player1FinalTime < userFinalTime) && ((Player2FinalTime > userFinalTime) || (Player3FinalTime > userFinalTime)) || (Player2FinalTime < userFinalTime) && ((Player1FinalTime > userFinalTime) || (Player3FinalTime > userFinalTime)) || (Player3FinalTime < userFinalTime) && ((Player2FinalTime > userFinalTime) || (Player1FinalTime > userFinalTime))){positionend = "Second";}
		if ((Player1FinalTime < userFinalTime) && (Player2FinalTime < userFinalTime) && (Player3FinalTime < userFinalTime)) {positionend = "Last";}

	

		c3 = Random.Range (PlayerPrefs.GetInt ("easyspeed011"),PlayerPrefs.GetInt ("easyspeed11"));
		c2 = Random.Range (PlayerPrefs.GetInt ("easyspeed011"),PlayerPrefs.GetInt ("easyspeed22"));
		c1 = Random.Range (PlayerPrefs.GetInt ("easyspeed011"),PlayerPrefs.GetInt ("easyspeed33"));


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
		}

}
