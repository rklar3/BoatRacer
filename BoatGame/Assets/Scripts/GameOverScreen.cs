using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {


	//public string nextlevel = "Level2";
	public int levelTOUnlock; 


	public void LoadScene(string sceneName){

		SceneManager.LoadScene (sceneName);

	}

	public void Retry(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}


	public void winLevel(){
		Debug.Log ("Level won");
		print ("Level Reached" + PlayerPrefs.GetInt ("levelReached"));

		if (PlayerPrefs.GetInt ("levelReached") >= levelTOUnlock) {
			//dont unlock the next level, since it is already unlocked.
		} else {
			PlayerPrefs.SetInt("levelReached",levelTOUnlock);
			print ("Level to unlock" + levelTOUnlock);
		}
		print ("Level Reached" + PlayerPrefs.GetInt("levelReached"));

		//SceneManager.LoadScene (nextlevel);

	}


}
