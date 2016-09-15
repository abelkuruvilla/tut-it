using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {


	bool touched,startwait,gameOv;


	Vector3 delta,start,fin;
	Vector3 objPos;

	Animator anim;


	int score;
	float starttime;
	GameObject g,particle;

	public AudioSource point1,point2,goAudio;



	// Use this for initialization
	void Start () {
		delta = new Vector3();
		start = Camera.main.ScreenToWorldPoint(Input.mousePosition );
		anim = GetComponent<Animator> ();
		g = GameObject.Find ("GOCanvas");
		g.SetActive (false);
		particle = GameObject.Find ("Explod Particle");
		particle.SetActive (false);
		startwait = true;
		gameOv = false;
		StartCoroutine (waitTime ());
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			touched = true;
			handletouches ();
		} else {
			touched = false;
		}


			
	}

	void handletouches(){
		if (Input.GetTouch (0).phase == TouchPhase.Moved && touched && !startwait) {



			fin = Camera.main.ScreenToWorldPoint( Input.mousePosition);
			delta = fin - start;



			gameObject.transform.position += delta;


			start = fin;


		}
		if (Input.GetTouch (0).phase == TouchPhase.Began) {
			start = Camera.main.ScreenToWorldPoint( Input.mousePosition);

		}
		if (Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (0).phase == TouchPhase.Canceled ) {
			if(!gameOv)
				gameOver ();

		}



	
	
	
	
	}

	void gameOver(){
		
		//anim.SetTrigger ("ballhit");
		gameOv = true;
		Handheld.Vibrate();
		goAudio.Play ();
		gameObject.GetComponent<SpriteRenderer>().enabled=false;
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		particle.gameObject.transform.position = gameObject.transform.position;
		particle.SetActive (true);
		Camera.main.GetComponent<Animator> ().SetTrigger ("gameover");

		StartCoroutine (viewGO ());






	}

	void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.tag == "obstacle" && !gameOv) {
			gameOver ();
		}
		if (other.gameObject.tag == "heart" && !gameOv) {
			GameObject g = GameObject.Find ("InGameCanvas/Score");
			g.GetComponent<ScoreShow> ().setScore (1);
			Destroy (g);


		}


	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "obstacle") {
			gameOver ();
		}
		if (other.gameObject.tag == "heart") {
			GameObject g = GameObject.Find ("InGameCanvas/Score");
			g.SendMessage ("setScore",1);
			Destroy (other.gameObject);
			point1.Play ();


		}
		if (other.gameObject.tag == "diamond") {
			GameObject g = GameObject.Find ("InGameCanvas/Score");
			g.SendMessage ("setScore",2);
			Destroy (other.gameObject);
			point2.Play ();
		}
	}

	/*public void setScore(int plus=0){
		score = score + plus;

		GameObject g = GameObject.Find ("Canvas/Score");
		g.SendMessage("


	}*/
	IEnumerator viewGO(){

		yield return new WaitForSeconds (2f);

		g.SetActive (true);
		GameObject scoreText = GameObject.Find ("InGameCanvas/Score");
		scoreText.SendMessage ("finalScore");

		Destroy (gameObject);
	}

	IEnumerator waitTime(){

		yield return new WaitForSeconds (2f);
		startwait = false;
	}
}
