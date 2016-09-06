using UnityEngine;
using System.Collections;

public class ResolutionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 800f / 1280f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
