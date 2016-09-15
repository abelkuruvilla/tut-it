using UnityEngine;
using System.Collections;

public class ObstacleDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (this.transform.position.y <= -25f)
			DestroyImmediate (gameObject);
	}
}
