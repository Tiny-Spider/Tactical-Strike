using UnityEngine;
using System.Collections;
using UnityEditor;

public static class ScriptableObjectCreator {
    
    [MenuItem ("Assets/Create/Unit")]
    public static void CreateUnit() {
        UnitObject unit = ScriptableObject.CreateInstance<UnitObject>();
        ProjectWindowUtil.CreateAsset(unit, "Assets/Resources/New Unit.asset");
    }

    [MenuItem("Assets/Create/Map")]
    public static void CreateMap() {
        MapData map = ScriptableObject.CreateInstance<MapData>();
        ProjectWindowUtil.CreateAsset(map, "Assets/Resources/New Unit.asset");
    }
}
