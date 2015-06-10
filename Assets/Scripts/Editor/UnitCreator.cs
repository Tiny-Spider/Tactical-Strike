using UnityEngine;
using System.Collections;
using UnityEditor;

public static class UnitCreator {
    
    [MenuItem ("Assets/Create/Unit")]
    public static void CreatUnity(){
            UnitData unit = ScriptableObject.CreateInstance<UnitData>();
        ProjectWindowUtil.CreateAsset(unit,"New Unit.asset");
    }
}
