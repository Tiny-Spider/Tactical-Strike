using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour{

    public Dictionary<UnitObject, UnitType> unitList = new Dictionary<UnitObject, UnitType>();

    public void LoadUnits() {
        UnitObject[] unitObjects = Resources.LoadAll<UnitObject>("Units");
        foreach(UnitObject _unit in unitObjects){
            unitList.Add(_unit, _unit.unitType);
            //[debug]print("Added " + _unit.name + " as " + _unit.unitType);
        }
        //[debug]print("The list contains " + unitList.Count + " units.");
    }
  
}
