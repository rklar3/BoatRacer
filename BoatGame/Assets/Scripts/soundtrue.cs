using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class soundtrue : MonoBehaviour {

	public Toggle sound;

	public  void OnEnable() {
		
		if (sound.isOn) {
			AudioSource audiocorrect = GetComponent<AudioSource> ();
			//audiocorrect.Play();
			print ("Sound On");
		}
		else			
			print("Sound is off");

	}
}
