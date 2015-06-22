using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {
    private static List<Unit> units;

    void Start() {
        Unit[] units = Resources.LoadAll<Unit>("Units");

        if (units.Length <= 0) {
            Debug.LogError("No units were loaded!");
        }

        UnitManager.units = new List<Unit>(units);
    }

    public static List<Unit> GetUnits() {
        return units;
    }

    public static Unit GetUnit(string techName) {
        foreach (Unit unit in units) {
            if (unit.techName == techName) {
                return unit;
            }
        }

        Debug.LogError("Unit not found by techName! techName: \"" + techName + "\"");
        return null;
    }
}
