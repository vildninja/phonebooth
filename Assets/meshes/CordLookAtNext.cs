using UnityEngine;
using System.Collections;

public class CordLookAtNext : MonoBehaviour {

    Transform target;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (target)
        {
            transform.LookAt(target);
        }
        else
        {
            target = GetComponent<SpringJoint>().connectedBody.transform;
        }
	}
}
