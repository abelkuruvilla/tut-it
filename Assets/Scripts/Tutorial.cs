using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (waitTime ());
	
	}
	
	IEnumerator waitTime(){

		yield return new WaitForSeconds (3f);
		Destroy (gameObject);
	}

}
