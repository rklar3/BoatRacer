using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class levelSelect : MonoBehaviour {


	public Button[] levelButtons;



	void Start()
	{
		int levelReached = PlayerPrefs.GetInt ("levelReached",1);

		//print (levelReached);

		for (int i = 0; i < levelButtons.Length; i++) 
		{
			if (i + 1 > levelReached)
			levelButtons [i].interactable = false;

		}

	}


	public void LoadScene(string levelname){

		SceneManager.LoadScene (levelname);

	}

}
