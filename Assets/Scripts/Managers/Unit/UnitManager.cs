using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour{

    public Dictionary<UnitData, UnitType> unitList = new Dictionary<UnitData, UnitType>();

    public void LoadUnits() {
        UnitData[] unitObjects = Resources.LoadAll<UnitData>("Units");
        foreach(UnitData _unit in unitObjects){
            unitList.Add(_unit, _unit.unitType);
            //[debug]print("Added " + _unit.name + " as " + _unit.unitType);
        }
        //[debug]print("The list contains " + unitList.Count + " units.");
    }
  
}
