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
		GameObject speed;
		speed = GameObject.Find ("Obstacle");
		score = score + extra;
		GetComponent<Text> ().text = score.ToString ();
		if(score >= 5){
			
			speed.GetComponent<ObstacleG> ().setSpeed (2.2f);

		}

		else if(score >15){

			speed.GetComponent<ObstacleG> ().setSpeed (2.6f);

		}
		else if(score >= 25){

			speed.GetComponent<ObstacleG> ().setSpeed (3f);

		}
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
