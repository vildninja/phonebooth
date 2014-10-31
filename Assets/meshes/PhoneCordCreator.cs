using UnityEngine;
using System.Collections;

public class PhoneCordCreator : MonoBehaviour {

    public Transform phonebooth;
    public Transform handle;
    public Transform cordParent;

	// Use this for initialization
	void Start ()
    {
        cordParent.parent = phonebooth;
        var p = cordParent;
        while (p.childCount > 0)
        {
            var c = p.GetChild(0);
            c.parent = phonebooth;
            var joint = p.GetComponent<SpringJoint>();
            joint.connectedBody = c.rigidbody;
            joint.minDistance = Vector3.Distance(c.position, p.position) / 4;
            joint.maxDistance = Vector3.Distance(c.position, p.position) / 4;
            joint.spring = 9999999;
            p = c;
        }
        p.GetComponent<SpringJoint>().connectedBody = handle.rigidbody;
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
