using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour{

    public static UnitManager instance;
    public Dictionary<string, UnitData> unitData = new Dictionary<string, UnitData>();
    public Dictionary<int, Unit> unitList = new Dictionary<int, Unit>();

    public static int globalUnitID;


    void Awake()
    {
        instance = this;
    }

    public UnitData GetUnitData(string unitName)
    {
        return unitData[unitName];
    }

    public void LoadUnits() {
        UnitData[] unitObjects = Resources.LoadAll<UnitData>("Units");
        foreach(UnitData _unit in unitObjects){
            unitData.Add(_unit.name, _unit);
             /*[debug]*/print("Added " + _unit.name + " as " + _unit.name);
        }
        /*[debug]*/print("The list contains " + unitData.Count + " units.");
    }

    public void SpawnUnit(string unitName) {

    }

    public void SpawnUnit(string unitName, int amount) {

    }
}
