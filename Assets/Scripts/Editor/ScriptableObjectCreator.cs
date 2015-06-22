using UnityEngine;
using UnityEditor;
using System.Collections;

public static class ScriptableObjectCreator {

    [MenuItem("Assets/Create/Map")]
    public static void CreateMap() {
        MapData map = ScriptableObject.CreateInstance<MapData>();
        ProjectWindowUtil.CreateAsset(map, "Assets/Resources/Maps/New Map.asset");
    }

    [MenuItem("Assets/Create/Faction")]
    public static void CreateFaction() {
        Faction faction = ScriptableObject.CreateInstance<Faction>();
        ProjectWindowUtil.CreateAsset(faction, "Assets/Resources/Factions/New Faction.asset");
    }
}
