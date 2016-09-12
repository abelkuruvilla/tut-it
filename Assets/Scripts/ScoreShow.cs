using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreShow : MonoBehaviour {

	public int score;


	// Use this for initialization
	void Start () {
		score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setScore(int extra){
		score = score + extra;
		GetComponent<Text> ().text = score.ToString ();

	}
}
