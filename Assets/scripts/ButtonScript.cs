using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public int value = -1;

	public AudioSource buttonSound;

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
		PlayButtonSound ();

		phone.OnButtonPress (value);	
	}

	void PlayButtonSound ()
	{
		buttonSound.Play ();
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(key)) {
			activate();
		}
	}

}
