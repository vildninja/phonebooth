using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneController : MonoBehaviour {

	public string phoneNr; 

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
		if (phonebook.ContainsKey (phoneNr)) {
			Debug.Log("omg: calling " + phonebook[phoneNr] );

			PhoneNode pn =  phonebook[phoneNr]; 
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
