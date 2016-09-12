using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PointGenerate : MonoBehaviour {


	List<GameObject> points;
	float time;
	// Use this for initialization
	void Start () {
		GameObject[] go = Resources.LoadAll<GameObject> ("points");
		points = go.ToList ();
		time= Random.Range(5f,9f);

		StartCoroutine (generatePoint ());
	}
	
	// Update is called once per frame
	void Update () {
		setTime ();

	
	}

	void setTime(){
		

	}

	IEnumerator generatePoint (){

		yield return new WaitForSeconds (time);

		Instantiate (getObject (), getPosition (), Quaternion.identity);
		time= Random.Range(5f,9f);
		StartCoroutine (generatePoint ());

	}

	GameObject getObject(){
		GameObject g = points [Random.Range (0, points.Count)];

		return g;




	}

	Vector3 getPosition(){

		Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), 10f));

		return pos;


	}






}
