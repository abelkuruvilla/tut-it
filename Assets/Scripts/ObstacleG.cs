using UnityEngine;
using System.Collections;

public class ObstacleG : MonoBehaviour {


	public GameObject[] obstacles;



	// Use this for initialization
	void Start () {
		obstacles =(GameObject[]) Resources.LoadAll ("");
		for (int i = 0; i < 5; i++) {
			Instantiate (obstacles [i]);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
