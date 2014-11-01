using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	bool firstRun;

	public Animator firstAnimation = null;

	// Use this for initialization
	void Start () {
		if (firstAnimation != null) {
			firstAnimation.animation.Stop();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			if (firstAnimation != null) {
				firstAnimation.animation.Play();
			}
		}
	}

	void RunAnimation() {

	}
}
