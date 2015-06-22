using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {
    private static List<MapData> maps;

    void Start() {
        MapData[] maps = Resources.LoadAll<MapData>("Maps");

        if (maps.Length <= 0) {
            Debug.LogError("No maps were loaded!");
        }

        MapManager.maps = new List<MapData>(maps);
    }

    public static List<MapData> GetMaps() {
        return maps;
    }

    public static MapData GetMapByScene(string sceneName) {
        foreach (MapData map in maps) {
            if (map.sceneName == sceneName) {
                return map;
            }
        }

        Debug.LogError("Map not found by scene! Scene: \"" + sceneName + "\"");
        return null;
    }
}
