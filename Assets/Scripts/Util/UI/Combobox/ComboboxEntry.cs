using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ComboboxEntry : MonoBehaviour {
    public Image image;
    public Text text;

    private Action hideAction;
    private Action action;

    public void Initalize(string name, Action action, Action hideAction) {
        this.action = action;
        this.hideAction = hideAction;

        text.text = name;
    }

    public void OnClick() {
        hideAction.Invoke();
        action.Invoke();
    }
}
