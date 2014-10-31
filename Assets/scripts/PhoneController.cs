using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneController : MonoBehaviour {

	private string phoneNumberToCall; 

	static Dictionary <string, PhoneNode> phonebook;

	// Use this for initialization
	void Start () {	

		phonebook = new Dictionary<string, PhoneNode> ();

		var pns = FindObjectsOfType<PhoneNode> ();
		for (int i = 0; i < pns.Length; i++) {
			PhoneNode pn = pns[i];
			phonebook[pn.phoneNumber] = pn;			
		}

//		Debug.Log (ps.Length);
	}
	
	void TryMatchNumber (string phoneNr)
	{
		if (phoneNr.Length > 0 && phonebook.ContainsKey (phoneNr)) {
			Debug.Log("omg: calling " + phonebook[phoneNr] );

			PhoneNode pn = phonebook[phoneNr]; 
			pn.Activate();
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
		phoneNumberToCall = ""; // clear phone number
	}

	public void OnButtonPress(int value) {

		phoneNumberToCall += value.ToString ();

		TryMatchNumber (phoneNumberToCall);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			OnButtonPress(1);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			OnButtonPress(2);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			OnButtonPress(3);
		}
	}
}
