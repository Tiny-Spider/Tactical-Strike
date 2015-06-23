using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Combobox : MonoBehaviour {
    public ComboboxEntry prefab;
    public VerticalLayoutGroup content;

    private Dictionary<string, ComboboxEntry> entries = new Dictionary<string, ComboboxEntry>();

    void Awake() {
        Clear();
    }

    public void Toggle() {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public ComboboxEntry Add(string name, string buttonName, Action action) {
        ComboboxEntry entry = Instantiate(prefab);

        entry.Initalize(buttonName, action, () => Hide());
        entry.transform.SetParent(content.transform);

        entries.Add(name, entry);

        return entry;
    }

    public void Remove(string name) {
        ComboboxEntry entry = entries[name];

        if (entry && entries.Remove(name)) {
            Destroy(entry);
        }
    }

    public void Clear() {
        if (!content)
            return;

        ComboboxEntry[] entries = content.GetComponentsInChildren<ComboboxEntry>();

        foreach (ComboboxEntry entry in entries) {
            Destroy(entry.gameObject);
        }
    }
}
