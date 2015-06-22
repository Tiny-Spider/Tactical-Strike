using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BuildEntry : MonoBehaviour {
    public Image image;

    private Action action;

    public void Initalize(Structure structure, Action action) {
        image.sprite = structure.image;
        this.action = action;
    }

    public void Build() {
        action.Invoke();
    }
}
