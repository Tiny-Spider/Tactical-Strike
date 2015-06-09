using UnityEngine;
using System.Collections;
using UnityEditor;

public static class ScriptableObjectCreator {
    
    [MenuItem ("Assets/Create/Unit")]
    public static void CreateUnit() {
        UnitData unit = ScriptableObject.CreateInstance<UnitData>();
        ProjectWindowUtil.CreateAsset(unit, "Assets/Resources/Units/New Unit.asset");
    }

    [MenuItem("Assets/Create/Map")]
    public static void CreateMap() {
        MapData map = ScriptableObject.CreateInstance<MapData>();
        ProjectWindowUtil.CreateAsset(map, "Assets/Resources/Maps/New Map.asset");
    }
}
