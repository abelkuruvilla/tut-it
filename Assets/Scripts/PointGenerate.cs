using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PointGenerate : MonoBehaviour {


	GameObject heart,diamond;
	float time;


	void Awake(){
		heart = Resources.Load<GameObject> ("points/heart");
		diamond = Resources.Load<GameObject> ("points/DIAMOND3");

	
	}
	// Use this for initialization
	void Start () {
		

		time= Random.Range(5f,9f);

		StartCoroutine (generatePoint ());
		StartCoroutine (genHeart ());
	}
	
	// Update is called once per frame
	void Update () {
		setTime ();

	
	}

	void setTime(){
		

	}

	IEnumerator generatePoint (){

		yield return new WaitForSeconds (time);

		Instantiate (heart, getPosition (), Quaternion.identity);
		time= Random.Range(4f,6f);
		StartCoroutine (generatePoint ());

	}



	Vector3 getPosition(){

		Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), 10f));

		return pos;


	}
	IEnumerator genHeart(){

		yield return new WaitForSeconds(Random.Range(40,50));
		Instantiate (diamond, getPosition (), Quaternion.identity);

		StartCoroutine (genHeart ());

	}






}
