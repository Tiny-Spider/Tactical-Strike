using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapDisplayer : MonoBehaviour {
    public MapEntry entryPrefab;
    public MenuPanel menuPanel;
    public MenuControl menuControl;

    public Color colorEven;
    public Color colorOdd;

    void Awake() {
        Clear();
    }

    void Start() {
        Refresh();
    }

    public void ClosePopup() {
        menuControl.HidePanel(menuPanel);
    }

    void Clear() {
        MapEntry[] entries = GetComponentsInChildren<MapEntry>();

        foreach (MapEntry entry in entries) {
            Destroy(entry.gameObject);
        }
    }

    void Refresh() {
        List<MapData> maps = MapManager.GetMaps();

        Clear();

        int current = 0;

        foreach (MapData map in maps) {
            MapEntry entry = Instantiate(entryPrefab);

            entry.Initalize(this, map);
            entry.transform.SetParent(transform);
            entry.SetColor(current % 2 == 0 ? colorEven : colorOdd);

            current++;
        }
    }
}
