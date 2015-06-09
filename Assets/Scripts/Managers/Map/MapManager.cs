using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {
    public static MapManager instance { private set; get; }

    private List<MapData> maps;

    void Awake() {
        instance = this;
    }

    void Start() {
        MapData[] maps = Resources.LoadAll<MapData>("Maps");

        if (maps.Length <= 0) {
            Debug.LogError("No maps were loaded!");
        }

        this.maps = new List<MapData>(maps);
    }

    public List<MapData> GetMaps() {
        return maps;
    }

    public MapData GetMapByScene(string sceneName) {
        foreach (MapData map in maps) {
            if (map.sceneName == sceneName) {
                return map;
            }
        }

        Debug.LogError("Map not found by scene! Scene: \"" + sceneName + "\"");
        return null;
    }
}
