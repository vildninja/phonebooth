using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneNode : MonoBehaviour {

    public static Dictionary<string, State> saved = new Dictionary<string, State>();

    public string phoneNumber = "";

    public string statement;
    public Answer[] answers;
    public PhoneNode[] next;

//    [HideInInspector]
    public State answer = State.NONE;

    public enum State
    {
        NONE,        
        PLAYED,
		HUNGUP,

		TRUE,
		FALSE,

        CONFIRMED,
        DECLINED,

		DENIED,
    }

    [System.Serializable]
    public struct Answer
    {
        public State state;
        public string text;
    }

    public bool Activate(string current = "")
    {
        bool activate = false;

        if (string.IsNullOrEmpty(statement))
        {
            activate = true;
        }
        else
        {
            var ands = statement.Split('&');

            activate = true;

            foreach (var a in ands)
            {
                bool t = false;
                var ors = a.Split('|');
                foreach (var o in ors)
                {
                    string c = current;
                    bool neg = false;

                    string[] tokens;
                    if (o.StartsWith("!"))
                    {
                        tokens = o.Substring(1).Split('-');
                        neg = true;
                    }
                    else
                    {
                        tokens = o.Split('-');
                    }

                    if (tokens.Length > 1)
                        c = tokens[1];

                    var state = (State)System.Enum.Parse(typeof(State), tokens[0]);
                    State savedState;
                    if (saved.TryGetValue(c, out savedState) && savedState == state)
                    {
                        t = true;
                        break;
                    }

                    if (neg)
                        t = !t;
                }
                if (!t)
                {
                    activate = false;
                    break;
                }
            }
        }

        if (activate)
            StartCoroutine(Play());
        return activate;
    }

    IEnumerator Play()
    {
        yield return null;
        isCurrentlyPlaying = true; // for visialization

        if (audio)
        {
            audio.Play();
            while (audio.isPlaying)
                yield return new WaitForSeconds(.2f);
        }

        if (answer == State.HUNGUP)
        {
            isCurrentlyPlaying = false;
            yield break;
        }

        if (answers.Length > 0)
        {
            FindObjectOfType<AnswerInput>().Initialize(this);

            while (answer == State.NONE)
                yield return new WaitForSeconds(.2f);

            if (saved.ContainsKey(name))
                saved[name] = answer;
            else
                saved.Add(name, answer);

            if (answer == State.HUNGUP)
            {
                isCurrentlyPlaying = false;
                yield break;
            }
        }
        else
        {
            if (saved.ContainsKey(name))
                saved[name] = State.PLAYED;
            else
                saved.Add(name, State.PLAYED);
        }

        if (next != null)
            foreach (var n in next)
                if (n.Activate(name))
                    break;
        isCurrentlyPlaying = false;
    }

    public void HangUp()
    {
        if (audio)
            audio.Stop();

        answer = State.HUNGUP;
    }

    bool isCurrentlyPlaying;
    void OnDrawGizmos()
    {

        if (!VerifySpelling())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.3f);
        }


        if (isCurrentlyPlaying)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.white;
            
            
        Gizmos.DrawSphere(transform.position, 0.2f);


        if (next != null)
            foreach (var pn in next)
                Gizmos.DrawLine(transform.position, pn.transform.position);
    }

    bool VerifySpelling()
    {
        if (string.IsNullOrEmpty(statement))
            return true;

        var tokens = statement.Split('&', '|');

        foreach (var token in tokens)
        {
            string[] split;
            if (token.StartsWith("!"))
            {
                split = token.Substring(1).Split('-');
            }
            else
            {
                split = token.Split('-');
            }

            try
            {
                System.Enum.Parse(typeof(State), split[0]);
            }
            catch
            {
                return false;
            }
            if (split.Length == 2)
            {
                if (!GameObject.Find(split[1]))
                    return false;
            }
        }
        return true;
    }
}
