using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour,IPointerEnterHandler {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerEnter(PointerEventData eventdata){
		string s = "Highlighted";
		anim.SetTrigger (s);

	}

	public void OnPointerExit(PointerEventData eventdata){
		string s = "Disabled";
		anim.SetTrigger (s);
	}

	public void loadScene(string name){
		SceneManager.LoadScene (name);
	}
}
