using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnswerInput : MonoBehaviour {

    public AnswerInputButton buttonPrefab;

    public Transform[] buttonPositions;

    public Texture green;
    public Texture red;

    List<AnswerInputButton> buttons = new List<AnswerInputButton>();

    PhoneNode node;

    public void Initialize(PhoneNode node)
    {
        this.node = node;

        for (int i = 0; i < node.answers.Length; i++)
        {
            var b = Instantiate(buttonPrefab, buttonPositions[i].position, buttonPositions[i].rotation) as AnswerInputButton;
            buttons.Add(b);
            b.state = node.answers[i].state;
            b.text = node.answers[i].text;

            switch (b.state)
            {
                case PhoneNode.State.CONFIRMED:
                    b.renderer.material.mainTexture = green;
                    break;
                case PhoneNode.State.DECLINED:
                    b.renderer.material.mainTexture = red;
                    break;
            }

        }
    }

    public void Answer(PhoneNode.State state)
    {
        node.answer = state;
        foreach (var b in buttons)
        {
            Destroy(b.gameObject);
        }
        buttons.Clear();
    }
}
