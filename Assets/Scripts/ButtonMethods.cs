using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonMethods : MonoBehaviour {

	public void retryButton(){

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);


	}

	public void homeButton(){

		SceneManager.LoadScene ("Scenes/home");
	}

	public void playButton(){
		SceneManager.LoadScene ("Scenes/Game");

	}

	public void exitButton(){
		Application.Quit ();
	}
}
