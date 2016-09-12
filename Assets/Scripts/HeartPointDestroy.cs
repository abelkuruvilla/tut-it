using UnityEngine;
using System.Collections;

public class HeartPointDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine (showPoint ());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator showPoint(){
		yield return new WaitForSeconds(Random.Range(5F,10F));
			Destroy(gameObject);

	}
	/*void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "ball") {
			Destroy (gameObject);
		}

		

	} */
}
