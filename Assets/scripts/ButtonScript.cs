using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public int value = -1;

	private TextMesh label;
	public KeyCode key;

	public PhoneController phone;

	// Use this for initialization
	void Start () {


		// debug stuff
		TextMesh[] t = this.GetComponentsInChildren<TextMesh> ();
		TextMesh label = t[0];
		this.label = label;
		this.label.text = value.ToString();

	}

	public void activate() {
		phone.OnButtonPress (value);	
	}


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(key)) {
			activate();
		}
	}

}
