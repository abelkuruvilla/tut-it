using UnityEngine;
using System.Collections;

public class BackGroundMusic : MonoBehaviour {

	public AudioSource myAudioSource;

	public static GameObject bgmObj;


	void Awake(){
		if (bgmObj) {
			Destroy (gameObject);
			return;
		}

		myAudioSource.Play ();
		bgmObj = gameObject;	



	}




}
