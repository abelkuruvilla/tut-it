using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {


	bool touched;
	bool over;

	Vector3 delta,start,fin;
	Vector3 objPos;

	Animator anim;


	int score;
	float starttime;



	// Use this for initialization
	void Start () {
		delta = new Vector3();
		start = Camera.main.ScreenToWorldPoint(Input.mousePosition );
		anim = GetComponent<Animator> ();
		over = false;
		score = 0;
		setScore (0);
		starttime = Time.time;
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
		if (Input.GetTouch (0).phase == TouchPhase.Moved && touched && !over) {


			score = (int)(Time.time - starttime)/5;
			setScore ();

			fin = Camera.main.ScreenToWorldPoint( Input.mousePosition);
			delta = fin - start;
			if (delta == Vector3.zero) {
				anim.SetTrigger ("idle");
			} else {
				anim.SetTrigger ("moving");
			}

			gameObject.transform.position += delta;


			start = fin;


		}
		if (Input.GetTouch (0).phase == TouchPhase.Began) {
			start = Camera.main.ScreenToWorldPoint( Input.mousePosition);
		}
		if (Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (0).phase == TouchPhase.Canceled) {
			gameOver ();

		}



	
	
	
	
	}

	void gameOver(){
		over = true;
		anim.applyRootMotion = false;
		anim.SetTrigger ("gameover");

		GameObject g = GameObject.Find ("Canvas");
		Animator[] child = g.GetComponentsInChildren<Animator> ();

		foreach (Animator i in child) {

			i.SetBool ("gameover", true);
		}




	}

	void OnCollisionEnter2D(Collision2D other){
		;

	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "obstacle") {
			gameOver ();
		}

	}

	public void setScore(int plus=0){
		score = score + plus;

		GameObject g = GameObject.Find ("Canvas/Score");
		g.GetComponent<Text> ().text = score.ToString ();


	}

}
