using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneNode : MonoBehaviour {

    public static Dictionary<string, State> saved = new Dictionary<string, State>();

    public string statement;
    public Answer[] answers;
    public PhoneNode[] next;

    [HideInInspector]
    public State answer = State.NONE;

    public enum State
    {
        NONE,
        HUNGUP,
        PLAYED,
        TRUE,
        FALSE,
        CONFIRMED,
        DENIED,
    }

    [System.Serializable]
    public struct Answer
    {
        public State state;
        public string text;
    }

    public bool Activate(string current)
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
                    var tokens = o.Split('-');
                    if (tokens.Length > 1)
                        c = tokens[1];

                    var state = (State)System.Enum.Parse(typeof(State), tokens[0]);
                    State savedState;
                    if (saved.TryGetValue(c, out savedState) && savedState == state)
                    {
                        t = true;
                        break;
                    }
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

        if (audio)
        {
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
        }

        if (answers.Length > 0)
        {
            FindObjectOfType<AnswerInput>().Initialize(this);

            while (answer == State.NONE)
                yield return null;

            saved.Add(name, answer);

            if (answer == State.HUNGUP)
                yield break;
        }
        else
        {
            saved.Add(name, State.PLAYED);
        }

        foreach (var n in next)
            if (n.Activate(name))
                break;
    }

    public void HangUp()
    {
        if (audio)
            audio.Stop();

        answer = State.HUNGUP;
    }

}
