using UnityEngine;
using System.Collections;

public class DummyStarter : MonoBehaviour {

    public PhoneNode init;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(3);
        init.Activate();
	}
}
