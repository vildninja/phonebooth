using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneController : MonoBehaviour {

	public string phoneNr; 

	static Dictionary <string, PhoneNode> phonebook;

	// Use this for initialization
	void Start () {	
		var p = FindObjectsOfType<PhoneNode> ();

		for (int i = 0; i < p.Length; i++) {
			PhoneNode pn = p[i];
		}
	}
	
	void TryMatchNumber (string phoneNr)
	{
		if (phonebook.ContainsKey (phoneNr)) {
			Debug.Log("omg: called " + phonebook[phoneNr] );
			// do something
			Reset ();
		}
		else {
			Debug.Log(phoneNr + " does not exist");
		}
	}

	public void HangUp() {
		Reset ();
	}

	void Reset() {
		phoneNr = ""; // clear phone number

	}

	public void OnButtonPress(int value) {

		phoneNr += value.ToString ();

		TryMatchNumber (phoneNr);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
