using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Handheld.PlayFullScreenMovie ("UI2.3gp", Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.AspectFit);
		StartCoroutine (mov ());
	}
	IEnumerator mov(){
		
		yield return new WaitForSeconds (4f);
		SceneManager.LoadScene ("Scenes/home");
	}

}
