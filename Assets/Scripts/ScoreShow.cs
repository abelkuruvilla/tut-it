using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreShow : MonoBehaviour {

	public int score;
	public int highScore;


	// Use this for initialization
	void Start () {
		score = 0;
		setScore (0);
		getHighScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setScore(int extra){
		score = score + extra;
		GetComponent<Text> ().text = score.ToString ();

	}
	public void finalScore(){
		if (score >= highScore) {
			PlayerPrefs.SetInt ("HighScore", score);
			highScore = score;

		}
		GameObject highscoreText = GameObject.Find ("GOCanvas/HighScore");
		highscoreText.GetComponent<Text> ().text = "HIGH SCORE : " + highScore.ToString ();


		GameObject scoreText = GameObject.Find ("GOCanvas/Score_Text");
		scoreText.GetComponent<Text> ().text = score.ToString ();  

	}
	public  void getHighScore(){
		if(PlayerPrefs.HasKey("HighScore")){
			highScore = PlayerPrefs.GetInt("HighScore");

		}

	}
}
