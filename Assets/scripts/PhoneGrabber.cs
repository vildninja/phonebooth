using UnityEngine;
using System.Collections;

public class PhoneGrabber : MonoBehaviour {

    public Transform handle;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(1f);

        while (Vector3.Distance(handle.position, transform.position) > 0.1f)
        {
            handle.position = Vector3.Lerp(handle.position, transform.position, 0.05f);
            handle.rotation = Quaternion.Lerp(handle.rotation, transform.rotation, 0.05f);
            yield return null;
        }

        handle.parent = transform;
	}
}
