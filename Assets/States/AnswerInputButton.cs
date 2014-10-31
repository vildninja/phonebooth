using UnityEngine;
using System.Collections;

public class AnswerInputButton : MonoBehaviour {

    public string text;
    public PhoneNode.State state;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            foreach (var hit in hits)
            {
                if (hit.collider == collider)
                {
                    FindObjectOfType<AnswerInput>().Answer(state);
                    break;
                }
            }
        }
	}
}
