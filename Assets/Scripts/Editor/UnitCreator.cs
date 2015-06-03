using UnityEngine;
using System.Collections;
using UnityEditor;

public static class UnitCreator {
    
    [MenuItem ("Assets/Create/Unit")]
    public static void CreatUnity(){
            UnitObject unit = ScriptableObject.CreateInstance<UnitObject>();
        ProjectWindowUtil.CreateAsset(unit,"New Unit.asset");
    }
}
