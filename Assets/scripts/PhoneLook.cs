using UnityEngine;
using System.Collections;

public class PhoneLook : MonoBehaviour {

    public AnimationCurve curve;
    public float horizontal;
    public float vertical;

	// Use this for initialization
	void Start ()
    {
        Screen.showCursor = false;
        Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(Input.mousePosition.x + " / " + Screen.width + " = " + (Input.mousePosition.x / Screen.width) + " -> " + (curve.Evaluate(Input.mousePosition.x / Screen.width) * horizontal));

        transform.rotation = Quaternion.Euler(curve.Evaluate(Input.mousePosition.y / Screen.height) * vertical, curve.Evaluate(Input.mousePosition.x / Screen.width) * horizontal, 0);
	}
}
