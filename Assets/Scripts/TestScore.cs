using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestScore : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {
		StartCoroutine (updateScore ());
	}

	IEnumerator updateScore(){
		yield return new WaitForSeconds (1f);
		GetComponent<Text> ().text =((int) Time.time).ToString ();
	}
}
