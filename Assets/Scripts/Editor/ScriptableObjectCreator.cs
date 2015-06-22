using UnityEngine;
using System.Collections;
using UnityEditor;

public static class ScriptableObjectCreator {

    [MenuItem("Assets/Create/Map")]
    public static void CreateMap() {
        MapData map = ScriptableObject.CreateInstance<MapData>();
        ProjectWindowUtil.CreateAsset(map, "Assets/Resources/Maps/New Map.asset");
    }
}
