using UnityEngine;
using System.Collections;

public class SquareScript : MonoBehaviour {

	public float velocity = -0.9f;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, velocity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
