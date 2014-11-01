using UnityEngine;
using System.Collections;

public class PhoneGrabber : MonoBehaviour {

    public Transform handle;

	public PhoneLook mouseLook;

	// Use this for initialization
	IEnumerator Start () {

		mouseLook.active = false;

        yield return new WaitForSeconds(1f);

        while (Vector3.Distance(handle.position, transform.position) > 0.1f)
        {
            handle.position = Vector3.Lerp(handle.position, transform.position, 0.25f);
            handle.rotation = Quaternion.Lerp(handle.rotation, transform.rotation, 0.25f);
            yield return null;
        }

        handle.parent = transform;
		mouseLook.active = true;
	}
}
