using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dontdestroy : MonoBehaviour {

	public bool soundOn = true;
	public GameObject button;	//soundon
	public GameObject button2;

	AudioSource audioSource;

	void start(){
		if (soundOn == true) {
			button.SetActive (false);
			button2.SetActive (true);
		}
	}
		
	void Awake(){
		audioSource = GetComponent<AudioSource>();
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("music");
		if(objs.Length > 1 ){
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}


	public void togglesound(){
		button.SetActive(false);
		button2.SetActive (true);
		soundOn = true;
		audioSource.mute = !audioSource.mute;

	}

	public void togglesound2(){
		button.SetActive(true);
		button2.SetActive(false);
		soundOn = false;
		audioSource.mute = !audioSource.mute;
	}



	void Update()
	{
		print (soundOn);

	}



}
