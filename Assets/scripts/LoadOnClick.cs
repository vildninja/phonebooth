using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.collider == collider)
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
	}
}
