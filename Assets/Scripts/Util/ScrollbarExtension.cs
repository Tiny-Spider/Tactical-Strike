using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollbarExtension : MonoBehaviour {
    public Scrollbar scrollbar;
    public Text scrollbarText;

    private float stepSize;

    void Awake() {
        stepSize = 1F / scrollbar.numberOfSteps;
    }

    void Start() {
        OnValueChanged(scrollbar.value);
    }

    public void IncreaseValue() {
        scrollbar.value = Mathf.Clamp01(scrollbar.value + stepSize);
    }

    public void DecreaseValue() {
        scrollbar.value = Mathf.Clamp01(scrollbar.value - stepSize);
    }

    public void OnValueChanged(float value) {
        if (scrollbarText != null) {
            scrollbarText.text = (scrollbar.value * 100) + "%";
        }
    }
}
