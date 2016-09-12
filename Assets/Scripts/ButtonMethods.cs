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
}
