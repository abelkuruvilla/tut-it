using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObstacleG : MonoBehaviour {

	public List<GameObject> obstacle;
	public GameObject[] ob;
	public float speed;


	GameObject obs,g1,g2;


	// Use this for initialization
	void Awake(){
		getObstacle ();
	}
	void Start () {
		
		//getObstacle ();
		speed=1.5f;
		generateObstacles (1);


	}

	void Update(){
		if (g1 != null) {
			g1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
			if (checkPosition (1)) {
				generateObstacles (2);

			}
		}
		if (g2 != null) {
			g2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
			if (checkPosition (2)) {

				generateObstacles (1);
			}
		}

		/*if(g1!=null)
			checkEnds (1);
		if(g2!=null)
			checkEnds (2);
		*/
	}
	

	public void setSpeed(float f){

		speed = f;

		if(g1!=null)
			g1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
		if(g2!=null)
			g2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
	}


	void generateObstacles(int opt){

		obs = obstacle [Random.Range (0,obstacle.Count)];
		//obs = obstacle [48];

		if (opt == 1) {
			g1 = Instantiate (obs);
			g1.transform.position = this.transform.position;
			g1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
		} else if (opt == 2) {
			g2 = Instantiate (obs);
			g2.transform.position = this.transform.position;
			g2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
		}


	}

	void getObstacle(){

		ob = Resources.LoadAll<GameObject> ("obstacles");

		obstacle = ob.ToList ();

		//GameObject gol = obstacle [Random.Range (0, obstacle.Count)];
			//Instantiate(gol);
	}

	bool checkPosition(int opt){
		if (opt == 1) {
			if (g1.transform.position.y <= 0f) {
				g1.AddComponent<ObstacleDestroy> () ;
				g1 = null;
				return true;

			}
			else
				return false;

		} else if (opt == 2) {
			if (g2.transform.position.y <= 0f) {
				g2.AddComponent<ObstacleDestroy> ();
				g2 =null;;
				return true;
			}
			else
				return false;
		} else
			return false;

	}

	/*void checkEnds(int opt){

		float edge = -Camera.main.WorldToScreenPoint (transform.position).y;
		Bounds bound;
		Vector3 top;


		if (opt == 1) {
			bound = g1.GetComponent<SpriteRenderer> ().bounds;
			top = Vector3(bound.extents.x,bound.extents.y,0)+g1.transform.position;
			top = transform.InverseTransformPoint(top);
			if( top.y <= edge)
				Destroy (g1);
		} else if (opt == 2) {
			bound = g2.GetComponent<SpriteRenderer> ().bounds;
			top = Vector3(0.0,bound.extents.y,0.0)+g2.transform.position;
			top = transform.InverseTransformPoint(top);
			if( top.y <= edge)
				Destroy (g2);

		}


	}
*/


}
