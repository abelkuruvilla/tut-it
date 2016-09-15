using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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



	public void toggleButton(){
		

		GameObject tb = GameObject.FindGameObjectWithTag ("toggle");
		if (tb.GetComponent<Toggle> ().isOn) {
			Camera.main.GetComponent<AudioListener> ().enabled = false;
			AudioListener.pause = true;
			PlayerPrefs.SetInt ("sound", 1);

		} else if (!tb.GetComponent<Toggle> ().isOn) {
			AudioListener.pause = false;
			Camera.main.GetComponent<AudioListener> ().enabled = true;
				PlayerPrefs.SetInt ("sound", 2);
			
		}

	}

		void Awake(){
		if (PlayerPrefs.HasKey ("sound")) {

			if (PlayerPrefs.GetInt ("sound") == 1) {
				Camera.main.GetComponent<AudioListener> ().enabled = false;
				AudioListener.pause = true;
				GameObject tb = GameObject.FindGameObjectWithTag ("toggle");
				if (tb != null) {
					tb.GetComponent<Toggle> ().isOn = true;
				}

			}
			else if (PlayerPrefs.GetInt ("sound") == 2) {
				Camera.main.GetComponent<AudioListener> ().enabled = true;
				AudioListener.pause = false;
				GameObject tb = GameObject.FindGameObjectWithTag ("toggle");
				if (tb != null) {
					tb.GetComponent<Toggle> ().isOn = false;
				}
			}

		}


		}
}
