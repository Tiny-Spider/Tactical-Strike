using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Collections;

public class InputFieldChecker : MonoBehaviour {
    [SerializeField]
    public Check[] checks;
    public Button[] buttons;

    public void Refresh() {
        bool succes = true;

        foreach (Check check in checks) {
            if (!isValid(check.inputField.text, check.checkType)) {
                succes = false;
                break;
            }
        }

        foreach (Button button in buttons) {
            button.interactable = succes;
        }
    }

    public bool isValid(string text, CheckType check) {
        int value;

        switch (check) {
            case CheckType.Int:
                return int.TryParse(text, out value);
            case CheckType.Port:
                int.TryParse(text, out value);
                return value > 0 && value <= 65535;
            case CheckType.IP:
                IPAddress address;
                return IPAddress.TryParse(text, out address);
            case CheckType.NotEmpty:
            default:
                return !text.IsEmpty();
        }
    }

    [System.Serializable]
    public struct Check {
        public InputField inputField;
        public CheckType checkType;
    }

    public enum CheckType {
        NotEmpty,
        Int,
        Port,
        IP
    }
}
