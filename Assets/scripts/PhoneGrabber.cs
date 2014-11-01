using UnityEngine;
using System.Collections;

public class PhoneGrabber : MonoBehaviour {

    public Transform handle;

	public float waitTime = 0.6f;

	// Use this for initialization
	IEnumerator Start () {

        yield return new WaitForSeconds(waitTime);

//		for (float t = 0; t < 1; t += Time.deltaTime)
//        {
//            handle.position = Vector3.Lerp(handle.position, transform.position, 0.25f);
////            handle.rotation = Quaternion.Lerp(handle.rotation, transform.rotation, 0.25f);
//            yield return null;
//        }

		handle.parent = transform;
	}
}
