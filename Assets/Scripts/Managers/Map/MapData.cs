using UnityEngine;
using System.Collections;

public class MapData : ScriptableObject {
    public Sprite image;
    public string name;
    public string sceneName;
    public int maxPlayers;

    public string GetInfo() {
        string mapInfoText =
            "Name:      " + name + System.Environment.NewLine +
            "Players:   " + "2-" + maxPlayers;

        return mapInfoText;
    }
}
