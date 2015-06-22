using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PoolManager : MonoBehaviour {

    public Dictionary<string, Unit> unitPool = new Dictionary<string, Unit>();
    public Dictionary<string, Structure> structurePool = new Dictionary<string, Structure>();

    public Unit GetUnit(string unitName) {
        return unitPool[unitName];
    }

    public Unit[] GetUnits(string unitName, int amount) {
        List<Unit> tempUnitArray;
        Unit tempUnit = unitPool[unitName];
        for (int i = 0; i < amount; i++)
        {
            tempUnitArray.Add(tempUnit);
        }
        return tempUnitArray.ToArray();
    }
}
