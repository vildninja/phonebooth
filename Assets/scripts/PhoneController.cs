using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneController : MonoBehaviour {

	public string phoneNr; 

	public static Dictionary <string, string> phonebook;

	// Use this for initialization
	void Start () {
		phonebook = new Dictionary<string, string> () {
			{"21", "1231 23 123 omg"},
		};
	}

	void tryMatchNumber (string phoneNr)
	{
		if (phonebook.ContainsKey (phoneNr)) {
			Debug.Log("omg: called " + phonebook[phoneNr] );
			// do something
			phoneNr.Length = 0; // clear phone number
		}
		else {
			Debug.Log(phoneNr + " does not exist");
		}
	}

	public void OnButtonPress(int value) {

		phoneNr += value.ToString ();

		tryMatchNumber (phoneNr);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
