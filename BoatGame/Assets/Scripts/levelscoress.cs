using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelscoress : MonoBehaviour {

		public Text level1scoretext;
		public Text level2scoretext;
		public Text level3scoretext;
		public Text level4scoretext;
		public Text level5scoretext;
		public Text level6scoretext;

		public float level1score;
		public float level2score;
		public float level3score;
		public float level4score;
		public float level5score;
		public float level6score;

		public void scores(){

		level1score = PlayerPrefs.GetFloat ("level1score");
		level2score = PlayerPrefs.GetFloat ("level2score");
		level3score = PlayerPrefs.GetFloat ("level3score");
		level4score = PlayerPrefs.GetFloat ("level4score");
		level5score = PlayerPrefs.GetFloat ("level5score");
		level6score = PlayerPrefs.GetFloat ("level6score");

		level1scoretext.text = "" + level1score;
		level2scoretext.text = "" + level2score;
		level3scoretext.text = "" + level3score;
		level4scoretext.text = "" + level4score;
		level5scoretext.text = "" + level5score;
		level6scoretext.text = "" + level6score;
			
		}

	public void Update(){
		scores ();
	}

	}


