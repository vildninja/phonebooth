using UnityEngine;
using System.Collections;

public class PushButton : MonoBehaviour {

    public int number;

	public AudioSource buttonSound = null;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.collider == collider)
            {
                var con = FindObjectOfType<PhoneController>();
                if (con)
                    con.OnButtonPress(number);
                StartCoroutine(Press());

				// play sound 
				if (buttonSound != null) {
					buttonSound.Play();
				}
            }
        }
	}

    int runs;
    IEnumerator Press()
    {
        if (runs > 0)
        {
            runs++;
        }
        else
        {
            runs = 1;
            while (runs > 0)
            {
                var target = transform.localScale;
                target.z = 0.11f;
                var real = transform.localScale;

                for (float t = -1; t < 1; t += Time.deltaTime * 4)
                {
                    yield return null;
                    transform.localScale = Vector3.Lerp(target, real, Mathf.Abs(t));
                }

                runs--;
            }
        }
    }
}
