using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneSwitcher : MonoBehaviour {
    private static bool hasSwitched = false;

    public bool disableTemporary = false;
    public int screenToSwitch = 0;

    void Start() {
        if (!disableTemporary) {
            if (screenToSwitch == 0) {
                if (Application.loadedLevel != 0 && !hasSwitched) {
                    Application.LoadLevel(screenToSwitch);
                }
            }
            else {
                Application.LoadLevel(screenToSwitch);
            }

            hasSwitched = true;
        }
    }
}
